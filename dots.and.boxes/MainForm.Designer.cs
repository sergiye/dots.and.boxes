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
      this.btnRestart = new System.Windows.Forms.Button();
      this.lblCurrentMove = new System.Windows.Forms.Label();
      this.lblPlayer2Score = new System.Windows.Forms.Label();
      this.lblPlayer1Score = new System.Windows.Forms.Label();
      this.lblPlayer2 = new System.Windows.Forms.Label();
      this.lblPlayer1 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
      this.panelControls.SuspendLayout();
      this.SuspendLayout();
      // 
      // gameBoard
      // 
      this.gameBoard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gameBoard.Location = new System.Drawing.Point(0, 142);
      this.gameBoard.Name = "gameBoard";
      this.gameBoard.Size = new System.Drawing.Size(779, 672);
      this.gameBoard.TabIndex = 0;
      this.gameBoard.TabStop = false;
      // 
      // panelControls
      // 
      this.panelControls.Controls.Add(this.btnRestart);
      this.panelControls.Controls.Add(this.lblCurrentMove);
      this.panelControls.Controls.Add(this.lblPlayer2Score);
      this.panelControls.Controls.Add(this.lblPlayer1Score);
      this.panelControls.Controls.Add(this.lblPlayer2);
      this.panelControls.Controls.Add(this.lblPlayer1);
      this.panelControls.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControls.Location = new System.Drawing.Point(0, 0);
      this.panelControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.panelControls.Name = "panelControls";
      this.panelControls.Size = new System.Drawing.Size(779, 142);
      this.panelControls.TabIndex = 1;
      // 
      // btnRestart
      // 
      this.btnRestart.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnRestart.ForeColor = System.Drawing.Color.RoyalBlue;
      this.btnRestart.Location = new System.Drawing.Point(337, 82);
      this.btnRestart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnRestart.Name = "btnRestart";
      this.btnRestart.Size = new System.Drawing.Size(125, 52);
      this.btnRestart.TabIndex = 5;
      this.btnRestart.Text = "Restart";
      this.btnRestart.UseVisualStyleBackColor = false;
      this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
      // 
      // lblCurrentMove
      // 
      this.lblCurrentMove.AutoSize = true;
      this.lblCurrentMove.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblCurrentMove.ForeColor = System.Drawing.Color.Crimson;
      this.lblCurrentMove.Location = new System.Drawing.Point(340, -18);
      this.lblCurrentMove.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCurrentMove.Name = "lblCurrentMove";
      this.lblCurrentMove.Size = new System.Drawing.Size(105, 105);
      this.lblCurrentMove.TabIndex = 4;
      this.lblCurrentMove.Text = "←";
      this.lblCurrentMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer2Score
      // 
      this.lblPlayer2Score.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer2Score.ForeColor = System.Drawing.Color.OrangeRed;
      this.lblPlayer2Score.Location = new System.Drawing.Point(633, 73);
      this.lblPlayer2Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPlayer2Score.Name = "lblPlayer2Score";
      this.lblPlayer2Score.Size = new System.Drawing.Size(129, 62);
      this.lblPlayer2Score.TabIndex = 3;
      this.lblPlayer2Score.Text = "0";
      this.lblPlayer2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer1Score
      // 
      this.lblPlayer1Score.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer1Score.ForeColor = System.Drawing.Color.SeaGreen;
      this.lblPlayer1Score.Location = new System.Drawing.Point(16, 73);
      this.lblPlayer1Score.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPlayer1Score.Name = "lblPlayer1Score";
      this.lblPlayer1Score.Size = new System.Drawing.Size(129, 62);
      this.lblPlayer1Score.TabIndex = 2;
      this.lblPlayer1Score.Text = "0";
      this.lblPlayer1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblPlayer2
      // 
      this.lblPlayer2.AutoSize = true;
      this.lblPlayer2.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer2.ForeColor = System.Drawing.Color.MidnightBlue;
      this.lblPlayer2.Location = new System.Drawing.Point(633, 26);
      this.lblPlayer2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPlayer2.Name = "lblPlayer2";
      this.lblPlayer2.Size = new System.Drawing.Size(122, 42);
      this.lblPlayer2.TabIndex = 1;
      this.lblPlayer2.Text = "Player 2";
      // 
      // lblPlayer1
      // 
      this.lblPlayer1.AutoSize = true;
      this.lblPlayer1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.lblPlayer1.ForeColor = System.Drawing.Color.MidnightBlue;
      this.lblPlayer1.Location = new System.Drawing.Point(16, 26);
      this.lblPlayer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPlayer1.Name = "lblPlayer1";
      this.lblPlayer1.Size = new System.Drawing.Size(122, 42);
      this.lblPlayer1.TabIndex = 0;
      this.lblPlayer1.Text = "Player 1";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(779, 814);
      this.Controls.Add(this.gameBoard);
      this.Controls.Add(this.panelControls);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Text = "Dots and Boxes";
      ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
      this.panelControls.ResumeLayout(false);
      this.panelControls.PerformLayout();
      this.ResumeLayout(false);

    }

    private System.Windows.Forms.PictureBox gameBoard;
    private System.Windows.Forms.Panel panelControls;

    #endregion

    private System.Windows.Forms.Label lblPlayer2Score;
    private System.Windows.Forms.Label lblPlayer1Score;
    private System.Windows.Forms.Label lblPlayer2;
    private System.Windows.Forms.Label lblPlayer1;
    private System.Windows.Forms.Label lblCurrentMove;
    private System.Windows.Forms.Button btnRestart;
  }
}