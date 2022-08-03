using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace dots.and.boxes {
  
  public partial class MainForm : Form {

    #region Paint setup

    private const int EmptyBordersSize = 20;
    private const int CellBorderWidth = 4;
    private const int PointWidth = CellBorderWidth * 2;

    private readonly Color boardBackColor;
    private readonly Pen clearBorderPen;
    private readonly Pen previewBorderPen;
    private readonly Pen filledBorderPen;
    private readonly Pen lastMoveBorderPen;
    private readonly SolidBrush pointBrush;
    private readonly SolidBrush player1CellBrush;
    private readonly SolidBrush player2CellBrush;
    private readonly SolidBrush previewCellBrush;
    
    #endregion
    
    #region game data

    private struct BoardSize {

      public int Columns { get; }
      public int Rows { get; }
      public int Width { get; }
      public int Height { get; }

      public BoardSize(int columns, int rows, int width, int height) {
        Columns = columns;
        Rows = rows;
        Width = width;
        Height = height;
      }
    }

    private static BoardSize[] boardSizes = new BoardSize[] { 
      new BoardSize(5, 5, 600, 700),
      new BoardSize(10, 7, 600, 500),
      new BoardSize(10, 10, 600, 700),
      new BoardSize(15, 10, 900, 700),
      new BoardSize(20, 10, 1200, 700),
      new BoardSize(20, 15, 1000, 800),
    };

    private readonly Timer moveTimer;
    private readonly Random random = new Random();

    private static int Columns = 10;
    private static int Rows = 10;

    private MoveInfo lastMove;
    
    private CellState[] boardData;
    
    private bool player1Move;
    internal bool Player1Move {
      get => player1Move;
      set {
        if (value == player1Move) return;
        player1Move = value;
        lblCurrentMove.Text = value ? "←" : "→";
      }
    }

    private int player1Score;
    internal int Player1Score {
      get => player1Score;
      set {
        if (value == player1Score ) return;
        player1Score = value;
        lblPlayer1Score.Text = $"{player1Score} Boxes";
      }
    }

    private int player2Score;
    internal int Player2Score {
      get => player2Score;
      set {
        if (value == player2Score ) return;
        player2Score = value;
        lblPlayer2Score.Text = $"{player2Score} Boxes";
      }
    }

    private CellState mouseCellState;
    internal CellState MouseCellState {
      get => mouseCellState;
      set {
        if (value == mouseCellState) return;
        mouseCellState = value;
        RedrawBoard();
      }
    }
    
    private int mouseColumn;
    internal int MouseColumn {
      get => mouseColumn;
      set {
        if (value == mouseColumn) return;
        mouseColumn = value;
        RedrawBoard();
      }
    }
    
    private int mouseRow;
    internal int MouseRow {
      get => mouseRow;
      private set {
        if (value == mouseRow) return;
        mouseRow = value;
        RedrawBoard();
      }
    }

    #endregion game data

    public MainForm() {
      
      InitializeComponent();

      Text = $"Dots and Boxes. Version: {Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}";
      
      Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
      StartPosition = FormStartPosition.CenterScreen;

      boardBackColor = Color.White;
      pointBrush = new SolidBrush(Color.Black);
      
      clearBorderPen = new Pen(Color.LightGray, 1);
      filledBorderPen = new Pen(Color.DarkOliveGreen, CellBorderWidth);
      lastMoveBorderPen = new Pen(Color.Magenta, CellBorderWidth);
      previewBorderPen = new Pen(Color.LightGreen, CellBorderWidth);

      player1CellBrush = new SolidBrush(lblPlayer1Score.ForeColor);
      player2CellBrush = new SolidBrush(lblPlayer2Score.ForeColor);
      previewCellBrush = new SolidBrush(Color.PaleGreen);

      moveTimer = new Timer();
      moveTimer.Interval = 300;
      moveTimer.Enabled = false;
      moveTimer.Tick += MoveTimerOnTick;

      gameBoard.Paint += GameBoardOnPaint;
      gameBoard.SizeChanged += (sender, args) => RedrawBoard(); //redraw on panel resize
      gameBoard.MouseMove += GameBoardOnMouseMove;
      gameBoard.MouseClick += GameBoardOnMouseClick;

      foreach (var size in boardSizes)
        this.toolStripSizes.Items.Add($"{size.Columns}x{size.Rows}");

      //load settings
      //var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\sergiye\\" + Application.ProductName);
      //if (key != null) {
      //  toolStripSizes.SelectedIndex = (int)key.GetValue("size", 2);
      //}
      
      //this.Closed += (s, e) => {
      //  //save settings
      //  if (key != null) {
      //    key.SetValue("size", toolStripSizes.SelectedIndex);
      //  }
      //};

      btnRestart_Click(this, EventArgs.Empty);
    }

    #region paint
    
    private void RedrawBoard() {
      gameBoard.Invalidate();
    }

    private void GameBoardOnPaint(object sender, PaintEventArgs e) {

      var g = e.Graphics;
      g.Clear(boardBackColor);
      // g.Clear(Color.FromArgb(253, 250, 231));
      var cellSize = new Size((gameBoard.Width - EmptyBordersSize * 2) / Columns, (gameBoard.Height - EmptyBordersSize * 2) / Rows);

      for (var x = 0; x < Columns; x++) {
        for (var y = 0; y < Rows; y++) {

          var cellX = cellSize.Width * x + EmptyBordersSize;
          var cellY = cellSize.Height * y + EmptyBordersSize;

          g.FillEllipse(pointBrush, cellX - CellBorderWidth, cellY - CellBorderWidth, PointWidth, PointWidth);
          if (x == Columns - 1)
            g.FillEllipse(pointBrush, cellSize.Width + cellX - CellBorderWidth, cellY - CellBorderWidth, PointWidth, PointWidth);
          if (y == Rows - 1)
            g.FillEllipse(pointBrush, cellX - CellBorderWidth, cellSize.Height + cellY - CellBorderWidth, PointWidth, PointWidth);

          var cellValue = boardData[GetIndex(x, y)];
          DrawCell(g, x, y, cellSize, cellValue, false);
          if (MouseColumn == x && MouseRow == y && !cellValue.HasFlag(MouseCellState)) {
            DrawCell(g, x, y, cellSize, cellValue, true);
          }
        }
      }
      //draw last point (right-bottom)
      g.FillEllipse(pointBrush, cellSize.Width * Columns + EmptyBordersSize - CellBorderWidth,
        cellSize.Height * Rows + EmptyBordersSize - CellBorderWidth, PointWidth, PointWidth);
    }

    private Pen GetCellBorderPen(int x, int y, CellState border) {
      if (lastMove != null && lastMove.X == x && lastMove.Y == y && lastMove.Border == border)
        return lastMoveBorderPen;

      return boardData[GetIndex(x, y)].HasFlag(border) ? filledBorderPen : clearBorderPen;
    }
    
    private void DrawCell(Graphics g, int x, int y, Size cellSize, CellState state, bool preview) {

      var cellX = cellSize.Width * x + EmptyBordersSize;
      var cellY = cellSize.Height * y + EmptyBordersSize;

      if (preview) {
        if (!state.HasFlag(CellState.Top) && MouseCellState.HasFlag(CellState.Top))
          g.DrawLine(previewBorderPen,
            cellX + CellBorderWidth * 2, cellY,
          cellX + cellSize.Width - CellBorderWidth * 2, cellY);
        if (!state.HasFlag(CellState.Bottom) && MouseCellState.HasFlag(CellState.Bottom))
          g.DrawLine(previewBorderPen,
            cellX + CellBorderWidth * 2, cellY + cellSize.Height,
            cellX + cellSize.Width - CellBorderWidth * 2, cellY + cellSize.Height);
        if (!state.HasFlag(CellState.Left) && MouseCellState.HasFlag(CellState.Left))
          g.DrawLine(previewBorderPen,
            cellX, cellY + CellBorderWidth * 2,
            cellX, cellY + cellSize.Height - CellBorderWidth * 2);
        if (!state.HasFlag(CellState.Right) && MouseCellState.HasFlag(CellState.Right))
          g.DrawLine(previewBorderPen,
            cellX + cellSize.Width, cellY + CellBorderWidth * 2,
            cellX + cellSize.Width, cellY + cellSize.Height - CellBorderWidth * 2);

        if (CountEmptyBorders(state) == 1)
          g.FillRectangle(previewCellBrush, cellX + 4, cellY + 4, cellSize.Width - 8, cellSize.Height - 8);
      }
      else {
        g.DrawLine(GetCellBorderPen(x, y, CellState.Top),
          cellX + CellBorderWidth * 2, cellY,
          cellX + cellSize.Width - CellBorderWidth * 2, cellY);
        g.DrawLine(GetCellBorderPen(x, y, CellState.Left),
          cellX, cellY + CellBorderWidth * 2,
          cellX, cellY + cellSize.Height - CellBorderWidth * 2);
        if (y == Rows - 1)
          g.DrawLine(GetCellBorderPen(x, y, CellState.Bottom),
            cellX + CellBorderWidth * 2, cellY + cellSize.Height,
            cellX + cellSize.Width - CellBorderWidth * 2, cellY + cellSize.Height);
        if (x == Columns - 1)
          g.DrawLine(GetCellBorderPen(x, y, CellState.Right),
            cellX + cellSize.Width, cellY + CellBorderWidth * 2,
            cellX + cellSize.Width, cellY + cellSize.Height - CellBorderWidth * 2);

        if (state.HasFlag(CellState.All)) {
          g.FillRectangle(state.HasFlag(CellState.OwnedByPlayer1) ? player1CellBrush : player2CellBrush, 
            cellX + 4, cellY + 4, cellSize.Width - 8, cellSize.Height - 8);
        }
      }
    }
    
    #endregion paint

    #region UI events

    private void ChangeBoardSize(object sender, EventArgs e) {
      var size = boardSizes[toolStripSizes.SelectedIndex];
      Columns = size.Columns;
      Rows = size.Rows;
      Width = size.Width;
      Height = size.Height;
      btnRestart_Click(this, EventArgs.Empty);
    }
    
    private void btnRestart_Click(object sender, EventArgs e) {

      boardData = new CellState[Columns * Rows];

      Player1Move = true;
      Player1Score = 0;
      Player2Score = 0;

      lastMove = null;
      
      RedrawBoard();
    }

    private void btnFill_Click(object sender, EventArgs e) {
      PreFillBoard();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      Close();
    }

    private void visitAppSiteToolStripMenuItem_Click(object sender, EventArgs e) {
      Process.Start("https://github.com/sergiye/dots.and.boxes");
    }

    private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e) {
      MessageBox.Show(
@"You and the computer take turns to place a line between to adjacent dots trying to form a box (by joining 4 dots with lines).

When you make a box, a blue square will appear inside it.When the computer makes a box, a yellow square will appear inside it.

The one who makes a box must take another turn.

The one who makes the most boxes by the time all dots are connected wins.

The game will determine at random whether you or the computer places the first line.

To place a line, move the mouse cursor to the place between two unconnected dots. When a faint line appears, click on the mouse to make the line permanent.",
        "How to play", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
      MessageBox.Show("App was developed by © Sergiy Egoshyn (egoshin.sergey@gmail.com)", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void GameBoardOnMouseMove(object sender, MouseEventArgs e) {

      var boardX = e.Location.X - EmptyBordersSize;
      var boardY = e.Location.Y - EmptyBordersSize;
      var cellWidth = (gameBoard.Width - EmptyBordersSize * 2) / Columns;
      var cellHeight = (gameBoard.Height - EmptyBordersSize * 2) / Rows;
      var borderClickWidth = cellWidth / 3;
   
      //skip borders
      if (boardX + borderClickWidth < 0 || boardX >= cellWidth * Columns + borderClickWidth ||
          boardY + borderClickWidth < 0 || boardY >= cellHeight * Rows + borderClickWidth) {
        MouseColumn = -1;
        MouseRow = -1;
        return;
      }

      MouseColumn = boardX / cellWidth;
      if (MouseColumn == Columns) MouseColumn = Columns - 1;
      MouseRow = boardY / cellHeight;
      if (MouseRow == Rows) MouseRow = Rows - 1;

      var emptyBorders = GetEmptyBorders(boardData[GetIndex(MouseColumn, MouseRow)]);
      if (emptyBorders.Count == 1) {
        MouseCellState = emptyBorders[0];
        return;
      }
      
      var cellX = boardX - MouseColumn * cellWidth;
      var cellY = boardY - MouseRow * cellHeight;

      var state = CellState.Empty;
      if (cellX <= borderClickWidth)
        state = CellState.Left;
      else if (cellX >= cellWidth - borderClickWidth)
        state = CellState.Right;
      else if (cellY <= borderClickWidth)
        state = CellState.Top;
      else if (cellY >= cellHeight - borderClickWidth)
        state = CellState.Bottom;

      MouseCellState = state;
    }

    private void GameBoardOnMouseClick(object sender, MouseEventArgs e) {
      
      if (e.Button != MouseButtons.Left) return;
      if (!Player1Move) return;
      
      if (MouseColumn == -1 || MouseRow == -1 || MouseCellState == CellState.Empty)
        return;

      var cellValue = boardData[GetIndex(MouseColumn, MouseRow)];
      if (cellValue.HasFlag(CellState.All))
        return;

      if (!cellValue.HasFlag(MouseCellState)) {
        if (!SetBorder(MouseColumn, MouseRow, MouseCellState, true)) {
          Player1Move = !Player1Move;
          if (!Player1Move) {
            //process computer move after delay
            moveTimer.Start();
          }
        }
      }

      RedrawBoard();
      
      if (Player1Move) {
        GameIsOver();
      }
    }

    #endregion

    #region logic

    private bool SetBorder(int x, int y, CellState border, bool sound) {

      if (border == CellState.Empty || border >= CellState.All)
        throw new ArgumentOutOfRangeException(nameof(border));
      
      //fix for paint optimization
      if (border == CellState.Right && x != Columns - 1) {
        x += 1;
        border = CellState.Left;
      }
      if (border == CellState.Bottom && y != Rows - 1) {
        y += 1;
        border = CellState.Top;
      }

      lastMove = new MoveInfo {X = x, Y = y, Border = border};
      if (sound) PlaySetBorderSound();
      var points = SetCellBorderState(boardData, lastMove.X, lastMove.Y, lastMove.Border, Player1Move);

      if (points > 0) {
        if (Player1Move)
          Player1Score += points;
        else
          Player2Score += points;
        return true;
      }
      return false;
    }
    
    private static int SetCellBorderState(CellState[] data, int x, int y, CellState state, bool player1Move, bool recursive = false) {

      if (x < 0 || y < 0 || x >= Columns || y >= Rows) return 0;
      //if (data[GetIndex(x, y)].HasFlag(state)) return 0;

      data[GetIndex(x, y)] |= state;
      var result = 0;
      if (data[GetIndex(x, y)].HasFlag(CellState.All)) {
        result++;
        if (player1Move) data[GetIndex(x, y)] |= CellState.OwnedByPlayer1;
      }

      if (recursive) return result;
      
      //set nearest cells borders
      if (state == CellState.Top)
        result += SetCellBorderState(data, x, y - 1, CellState.Bottom, player1Move, true);
      else if (state == CellState.Bottom)
        result += SetCellBorderState(data, x, y + 1, CellState.Top, player1Move, true);
      else if (state == CellState.Left)
        result += SetCellBorderState(data, x - 1, y, CellState.Right, player1Move, true);
      else if (state == CellState.Right) 
        result += SetCellBorderState(data, x + 1, y, CellState.Left, player1Move, true);
      return result;
    }

    private void PreFillBoard() {
      while (true) {
        var moves = FilterMoves(boardData, 4);
        if (moves.Count == 0) moves = FilterMoves(boardData, 3);
        if (moves.Count == 0)
          return;
        var selectedMove = moves[random.Next(moves.Count)];
        SetBorder(selectedMove.X, selectedMove.Y, selectedMove.Border, false);
        RedrawBoard();
      }
    }
    
    private void MoveTimerOnTick(object sender, EventArgs e) {
      moveTimer.Stop();

      if (GameIsOver()) return;

      var emptyBordersCount = 1;
      MoveInfo selectedMove;
      var moves = FilterMoves(boardData, 1);
      if (moves.Count == 0) {
        emptyBordersCount = 4;
        moves = FilterMoves(boardData, emptyBordersCount);
        if (moves.Count == 0) moves = FilterMoves(boardData, --emptyBordersCount);
        if (moves.Count == 0) moves = FilterMoves(boardData, --emptyBordersCount);
      }
      if (emptyBordersCount == 2) {
        var index = 0;
        var minPoints = Columns * Rows; //pessimistic by default all board
        for (var i = 0; i < moves.Count; i++) {
          var move = moves[i];
          //computer move
          var data = GetBoardCopy(boardData);
          SetCellBorderState(data, move.X, move.Y, move.Border, false);
          var count = GetNextMovePoints(data, minPoints);
          if (minPoints <= count) continue;
          index = i;
          minPoints = count;
        }
        
        selectedMove = moves[index];
      }
      else
        selectedMove = moves[random.Next(moves.Count)];
        
      if (SetBorder(selectedMove.X, selectedMove.Y, selectedMove.Border, true))
        moveTimer.Start();
      else
        Player1Move = true;
      RedrawBoard();
    }

    private static CellState[] GetBoardCopy(CellState[] source) {
      var data = new CellState[Columns * Rows];
      source.CopyTo(data, 0);
      return data;
    }

    private static int GetNextMovePoints(CellState[] data, int max) {
      var nextMoves = FilterMoves(data, 1);
      if (nextMoves.Count == 0) return 0;
      var result = 0;
      foreach (var move in nextMoves) {
        var nextData = data;
        // var nextData = nextMoves.Count == 1 ? data : GetBoardCopy(data);
        var res = SetCellBorderState(nextData, move.X, move.Y, move.Border, true);
        if (res == 0) continue;
        if (res > max) return max; //no need to calculate all
        res += GetNextMovePoints(nextData, max);
        if (res > result) 
          result = res;
      }
      return result;
    }
    
    private bool GameIsOver() {
      if (boardData.Any(c => !c.HasFlag(CellState.All)))
        return false;
      MessageBox.Show(Player1Score >= Player2Score ? "You are the champion!" : "Another one bites the dust...", 
        "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
      btnRestart_Click(this, EventArgs.Empty);
      return true;
    }
    
    private static int CountEmptyBorders(CellState state) {
      if (state.HasFlag(CellState.All))
        return 0;
      var result = 4;
      if (state.HasFlag(CellState.Top))
        result--;
      if (state.HasFlag(CellState.Left))
        result--;
      if (state.HasFlag(CellState.Bottom))
        result--;
      if (state.HasFlag(CellState.Right))
        result--;
      return result;
    }

    private static List<CellState> GetEmptyBorders(CellState state) {
      var result = new List<CellState>();
      if (state.HasFlag(CellState.All)) return result;
      if (!state.HasFlag(CellState.Top))
        result.Add(CellState.Top);
      if (!state.HasFlag(CellState.Left))
        result.Add(CellState.Left);
      if (!state.HasFlag(CellState.Bottom))
        result.Add(CellState.Bottom);
      if (!state.HasFlag(CellState.Right))
        result.Add(CellState.Right);
      return result;
    }
    
    private static List<MoveInfo> FilterMoves(CellState[] data, int emptyBordersNum) {
      var result = new List<MoveInfo>();
      for(var x = 0; x < Columns; x++)
      for (var y = 0; y < Rows; y++) {
        var borders = GetEmptyBorders(data[GetIndex(x, y)]);
        if (borders.Count != emptyBordersNum) continue;
        foreach (var border in borders) {
          if (emptyBordersNum > 1) {
            if (border == CellState.Left && x > 0 && CountEmptyBorders(data[GetIndex(x - 1, y)]) < emptyBordersNum) continue;
            if (border == CellState.Top && y > 0 && CountEmptyBorders(data[GetIndex(x, y - 1)]) < emptyBordersNum) continue;
            if (border == CellState.Bottom && y < Rows - 1 && CountEmptyBorders(data[GetIndex(x, y + 1)]) < emptyBordersNum) continue;
            if (border == CellState.Right && x < Columns - 1 && CountEmptyBorders(data[GetIndex(x + 1, y)]) < emptyBordersNum) continue;
          }
          result.Add(new MoveInfo {X = x, Y = y, Border = border});
        }
      }
      return result;
    }

    private static int GetIndex(int x, int y) {
      return x + Columns * y;
    }
    
    #endregion
    
    #region sounds

    private Stream GetResource(string name) {
      var type = GetType();
      //var all = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceNames();
      var assembly = Assembly.GetAssembly(type);
      var scriptsPath = $"{type.Namespace}.{name}";
      var result = assembly.GetManifestResourceStream(scriptsPath);
      if (result == null)
        throw new Exception($"Resource {name} is not found.");
      return result;
    }

    private void PlaySetBorderSound() {
      using (var p = new System.Media.SoundPlayer(GetResource("sounds.whip.wav"))) {
        p.Play();
      }
    }

    #endregion
  }
}