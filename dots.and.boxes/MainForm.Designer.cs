using System.ComponentModel;

namespace dots.and.boxes {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.gameBoard = new System.Windows.Forms.PictureBox();
      this.panelControls = new System.Windows.Forms.Panel();
      this.lblCurrentMove = new System.Windows.Forms.Label();
      this.lblPlayer2Score = new System.Windows.Forms.Label();
      this.lblPlayer1Score = new System.Windows.Forms.Label();
      this.lblPlayer2 = new System.Windows.Forms.Label();
      this.lblPlayer1 = new System.Windows.Forms.Label();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeBoardSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSizes = new System.Windows.Forms.ToolStripComboBox();
      this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.visitAppSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
      this.panelControls.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // gameBoard
      // 
      this.gameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gameBoard.Location = new System.Drawing.Point(0, 24);
      this.gameBoard.Margin = new System.Windows.Forms.Padding(2);
      this.gameBoard.Name = "gameBoard";
      this.gameBoard.Size = new System.Drawing.Size(584, 587);
      this.gameBoard.TabIndex = 0;
      this.gameBoard.TabStop = false;
      // 
      // panelControls
      // 
      this.panelControls.BackColor = System.Drawing.Color.CornflowerBlue;
      this.panelControls.Controls.Add(this.lblCurrentMove);
      this.panelControls.Controls.Add(this.lblPlayer2Score);
      this.panelControls.Controls.Add(this.lblPlayer1Score);
      this.panelControls.Controls.Add(this.lblPlayer2);
      this.panelControls.Controls.Add(this.lblPlayer1);
      this.panelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControls.Location = new System.Drawing.Point(0, 611);
      this.panelControls.Name = "panelControls";
      this.panelControls.Size = new System.Drawing.Size(584, 50);
      this.panelControls.TabIndex = 1;
      // 
      // lblCurrentMove
      // 
      this.lblCurrentMove.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lblCurrentMove.AutoSize = true;
      this.lblCurrentMove.Font = new System.Drawing.Font("Segoe Print", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblCurrentMove.ForeColor = System.Drawing.Color.Crimson;
      this.lblCurrentMove.Location = new System.Drawing.Point(243, -6);
      this.lblCurrentMove.Name = "lblCurrentMove";
      this.lblCurrentMove.Size = new System.Drawing.Size(52, 52);
      this.lblCurrentMove.TabIndex = 4;
      this.lblCurrentMove.Text = "←";
      // 
      // lblPlayer2Score
      // 
      this.lblPlayer2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPlayer2Score.AutoSize = true;
      this.lblPlayer2Score.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer2Score.ForeColor = System.Drawing.Color.Yellow;
      this.lblPlayer2Score.Location = new System.Drawing.Point(457, 4);
      this.lblPlayer2Score.Name = "lblPlayer2Score";
      this.lblPlayer2Score.Size = new System.Drawing.Size(102, 38);
      this.lblPlayer2Score.TabIndex = 3;
      this.lblPlayer2Score.Text = "0 Boxes";
      this.lblPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer1Score
      // 
      this.lblPlayer1Score.AutoSize = true;
      this.lblPlayer1Score.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer1Score.ForeColor = System.Drawing.Color.Blue;
      this.lblPlayer1Score.Location = new System.Drawing.Point(69, 4);
      this.lblPlayer1Score.Name = "lblPlayer1Score";
      this.lblPlayer1Score.Size = new System.Drawing.Size(102, 38);
      this.lblPlayer1Score.TabIndex = 2;
      this.lblPlayer1Score.Text = "0 Boxes";
      this.lblPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer2
      // 
      this.lblPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPlayer2.AutoSize = true;
      this.lblPlayer2.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer2.ForeColor = System.Drawing.Color.Gold;
      this.lblPlayer2.Location = new System.Drawing.Point(334, 7);
      this.lblPlayer2.Name = "lblPlayer2";
      this.lblPlayer2.Size = new System.Drawing.Size(117, 33);
      this.lblPlayer2.TabIndex = 1;
      this.lblPlayer2.Text = "Computer:";
      // 
      // lblPlayer1
      // 
      this.lblPlayer1.AutoSize = true;
      this.lblPlayer1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer1.ForeColor = System.Drawing.Color.Gold;
      this.lblPlayer1.Location = new System.Drawing.Point(10, 7);
      this.lblPlayer1.Name = "lblPlayer1";
      this.lblPlayer1.Size = new System.Drawing.Size(57, 33);
      this.lblPlayer1.TabIndex = 0;
      this.lblPlayer1.Text = "You:";
      // 
      // menuStrip1
      // 
      this.menuStrip1.BackColor = System.Drawing.Color.White;
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(584, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.changeBoardSizeToolStripMenuItem,
            this.fillToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripMenuItem1});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // restartToolStripMenuItem
      // 
      this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
      this.restartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
      this.restartToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.restartToolStripMenuItem.Text = "New game";
      this.restartToolStripMenuItem.Click += new System.EventHandler(this.btnRestart_Click);
      // 
      // changeBoardSizeToolStripMenuItem
      // 
      this.changeBoardSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSizes});
      this.changeBoardSizeToolStripMenuItem.Name = "changeBoardSizeToolStripMenuItem";
      this.changeBoardSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.changeBoardSizeToolStripMenuItem.Text = "Change size";
      // 
      // toolStripSizes
      // 
      this.toolStripSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.toolStripSizes.Name = "toolStripSizes";
      this.toolStripSizes.Size = new System.Drawing.Size(121, 23);
      this.toolStripSizes.SelectedIndexChanged += new System.EventHandler(this.ChangeBoardSize);
      // 
      // fillToolStripMenuItem
      // 
      this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
      this.fillToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
      this.fillToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.fillToolStripMenuItem.Text = "Fill";
      this.fillToolStripMenuItem.Click += new System.EventHandler(this.btnFill_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitAppSiteToolStripMenuItem,
            this.howToPlayToolStripMenuItem,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // visitAppSiteToolStripMenuItem
      // 
      this.visitAppSiteToolStripMenuItem.Name = "visitAppSiteToolStripMenuItem";
      this.visitAppSiteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
      this.visitAppSiteToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.visitAppSiteToolStripMenuItem.Text = "Visit app site";
      this.visitAppSiteToolStripMenuItem.Click += new System.EventHandler(this.visitAppSiteToolStripMenuItem_Click);
      // 
      // howToPlayToolStripMenuItem
      // 
      this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
      this.howToPlayToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
      this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.howToPlayToolStripMenuItem.Text = "How to play";
      this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(584, 661);
      this.Controls.Add(this.gameBoard);
      this.Controls.Add(this.panelControls);
      this.Controls.Add(this.menuStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "Dots and Boxes";
      ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
      this.panelControls.ResumeLayout(false);
      this.panelControls.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private System.Windows.Forms.ToolStripMenuItem changeBoardSizeToolStripMenuItem;


    private System.Windows.Forms.PictureBox gameBoard;
    private System.Windows.Forms.Panel panelControls;

    #endregion

    private System.Windows.Forms.Label lblPlayer2Score;
    private System.Windows.Forms.Label lblPlayer1Score;
    private System.Windows.Forms.Label lblPlayer2;
    private System.Windows.Forms.Label lblPlayer1;
    private System.Windows.Forms.Label lblCurrentMove;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem visitAppSiteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripComboBox toolStripSizes;
  }
}