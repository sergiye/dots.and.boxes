using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace dots.and.boxes {
  
  public partial class MainForm : Form {

    [Flags]
    internal enum CellState {
      Empty = 0,
      Top = 1,
      Left = 2,
      Bottom = 4,
      Right = 8,
      All = Top | Left | Bottom | Right,
      OwnedByPlayer1 = 16, //AllFilled & !OwnedByPlayer1 = OwnedByPlayer2
    }
    
    #region Paint setup

    private const int EmptyBordersSize = 20;
    private const int CellBorderWidth = 4;
    private const int PointWidth = CellBorderWidth * 2;

    private readonly Color boardBackColor;
    private readonly Pen clearBorderPen;
    private readonly Pen previewBorderPen;
    private readonly Pen filledBorderPen;
    private readonly SolidBrush pointBrush;
    private readonly SolidBrush player1CellBrush;
    private readonly SolidBrush player2CellBrush;
    
    #endregion
    
    #region game data

    private const int Columns = 10;
    private const int Rows = 10;
    
    private byte[,] boardData;
    
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
        lblPlayer1Score.Text = player1Score.ToString();
      }
    }

    private int player2Score;
    internal int Player2Score {
      get => player2Score;
      set {
        if (value == player2Score ) return;
        player2Score = value;
        lblPlayer2Score.Text = player2Score.ToString();
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
      
      Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
      StartPosition = FormStartPosition.CenterScreen;

      Width = 600;
      Height = 700;

      boardBackColor = Color.White;
      pointBrush = new SolidBrush(Color.Black);
      
      clearBorderPen = new Pen(Color.LightGray, 1);
      filledBorderPen = new Pen(Color.MediumBlue, CellBorderWidth);
      previewBorderPen = new Pen(Color.Goldenrod, CellBorderWidth);

      player1CellBrush = new SolidBrush(lblPlayer1Score.ForeColor);
      player2CellBrush = new SolidBrush(lblPlayer2Score.ForeColor);

      gameBoard.Paint += GameBoardOnPaint;
      gameBoard.SizeChanged += (sender, args) => RedrawBoard(); //redraw on panel resize
      gameBoard.MouseMove += GameBoardOnMouseMove;
      gameBoard.MouseClick += GameBoardOnMouseClick;
      
      StartNewGame();
    }

    private void StartNewGame() {

      boardData = new byte[Columns, Rows];
      for (var i = 0; i < Columns; i++)
      for (var j = 0; j < Rows; j++)
        boardData[i, j] = (byte) (CellState.Empty);

      Player1Move = true;
      Player1Score = 0;
      Player2Score = 0;
      
      RedrawBoard();
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

      for (var i = 0; i < Columns; i++) {
        for (var j = 0; j < Rows; j++) {

          var cellX = cellSize.Width * i + EmptyBordersSize;
          var cellY = cellSize.Height * j + EmptyBordersSize;

          //g.DrawRectangle(borderPen, cellX, cellY, cellSize.Width, cellSize.Height);

          g.FillEllipse(pointBrush, cellX - CellBorderWidth, cellY - CellBorderWidth, PointWidth, PointWidth);
          if (i == Columns - 1)
            g.FillEllipse(pointBrush, cellSize.Width + cellX - CellBorderWidth, cellY - CellBorderWidth, PointWidth, PointWidth);
          if (j == Rows - 1)
            g.FillEllipse(pointBrush, cellX - CellBorderWidth, cellSize.Height + cellY - CellBorderWidth, PointWidth, PointWidth);

          var cellValue = (CellState)boardData[i, j];
          DrawCell(g, i, j, cellSize, cellValue, false);
          if (MouseColumn == i && MouseRow == j && !cellValue.HasFlag(MouseCellState)) {
            DrawCell(g, i, j, cellSize, cellValue, true);
          }
        }
      }
      //draw last point (right-bottom)
      g.FillEllipse(pointBrush, cellSize.Width * Columns + EmptyBordersSize - CellBorderWidth,
        cellSize.Height * Rows + EmptyBordersSize - CellBorderWidth, PointWidth, PointWidth);
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
      }
      else {
        g.DrawLine(state.HasFlag(CellState.Top) ? filledBorderPen : clearBorderPen,
          cellX + CellBorderWidth * 2, cellY,
          cellX + cellSize.Width - CellBorderWidth * 2, cellY);
        g.DrawLine(state.HasFlag(CellState.Left) ? filledBorderPen : clearBorderPen,
          cellX, cellY + CellBorderWidth * 2,
          cellX, cellY + cellSize.Height - CellBorderWidth * 2);
        if (y == Rows - 1)
          g.DrawLine(state.HasFlag(CellState.Bottom) ? filledBorderPen : clearBorderPen,
            cellX + CellBorderWidth * 2, cellY + cellSize.Height,
            cellX + cellSize.Width - CellBorderWidth * 2, cellY + cellSize.Height);
        if (x == Columns - 1)
          g.DrawLine(state.HasFlag(CellState.Right) ? filledBorderPen : clearBorderPen,
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

    private void btnRestart_Click(object sender, EventArgs e) {
      StartNewGame();
    }

    private void GameBoardOnMouseMove(object sender, MouseEventArgs e) {

      var boardX = e.Location.X - EmptyBordersSize;
      var boardY = e.Location.Y - EmptyBordersSize;
      var cellWidth = (gameBoard.Width - EmptyBordersSize * 2) / Columns;
      var cellHeight = (gameBoard.Height - EmptyBordersSize * 2) / Rows;
   
      //skip borders
      if (boardX < 0 || boardX >= cellWidth * Columns ||
          boardY < 0 || boardY >= cellHeight * Rows) {
        MouseColumn = -1;
        MouseRow = -1;
        return;
      }

      MouseColumn = boardX / cellWidth;
      MouseRow = boardY / cellHeight;

      var cellX = boardX - MouseColumn * cellWidth;
      var cellY = boardY - MouseRow * cellHeight;

      var state = CellState.Empty;
      if (cellX <= CellBorderWidth)
        state = CellState.Left;
      else if (cellX >= cellWidth - CellBorderWidth)
        state = CellState.Right;
      else if (cellY <= CellBorderWidth)
        state = CellState.Top;
      else if (cellY >= cellHeight - CellBorderWidth)
        state = CellState.Bottom;

      MouseCellState = state;
    }

    private void GameBoardOnMouseClick(object sender, MouseEventArgs e) {
      
      if (e.Button != MouseButtons.Left) return;
      if (MouseColumn == -1 || MouseRow == -1 || MouseCellState == CellState.Empty)
        return;

      var cellValue = (CellState) boardData[MouseColumn, MouseRow];
      if (cellValue.HasFlag(CellState.All))
        return;

      if (!cellValue.HasFlag(MouseCellState)) {
        if (!SetCellBorderState(MouseColumn, MouseRow, MouseCellState)) {
          Player1Move = !Player1Move;
        }
      }

      RedrawBoard();
    }

    private bool SetCellBorderState(int x, int y, CellState state) {

      if (x < 0 || y < 0 || x >= Columns || y >= Rows) return false;

      var value = (CellState) boardData[x, y];
      if (value.HasFlag(state)) return false;

      value |= state;
      PlaySetBorderSound();
      var result = false;
      if (value.HasFlag(CellState.All)) {
        result = true;
        if (Player1Move) {
          value |= CellState.OwnedByPlayer1;
          Player1Score++;
        }
        else
          Player2Score++;
      }
      boardData[x, y] = (byte)(value);
      //set nearest cells borders
      if (state == CellState.Top)
        result = SetCellBorderState(x, y - 1, CellState.Bottom) || result;
      else if (state == CellState.Bottom)
        result = SetCellBorderState(x, y + 1, CellState.Top) || result;
      else if (state == CellState.Left)
        result = SetCellBorderState(x - 1, y, CellState.Right) || result;
      else if (state == CellState.Right) 
        result = SetCellBorderState(x + 1, y, CellState.Left) || result;

      return result;
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