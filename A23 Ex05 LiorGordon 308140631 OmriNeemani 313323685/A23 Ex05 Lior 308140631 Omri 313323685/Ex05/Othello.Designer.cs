
namespace Ex05
{
    partial class othello
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boardSize = new System.Windows.Forms.Button();
            this.vsCPU = new System.Windows.Forms.Button();
            this.vsPlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardSize
            // 
            this.boardSize.Location = new System.Drawing.Point(53, 32);
            this.boardSize.Name = "boardSize";
            this.boardSize.Size = new System.Drawing.Size(490, 58);
            this.boardSize.TabIndex = 0;
            this.boardSize.Text = "Board Size: 6x6 (click to increase)";
            this.boardSize.UseVisualStyleBackColor = true;
            this.boardSize.Click += new System.EventHandler(this.button1_Click);
            // 
            // vsCPU
            // 
            this.vsCPU.Location = new System.Drawing.Point(53, 106);
            this.vsCPU.Name = "vsCPU";
            this.vsCPU.Size = new System.Drawing.Size(242, 58);
            this.vsCPU.TabIndex = 1;
            this.vsCPU.Text = "Play against a computer";
            this.vsCPU.UseVisualStyleBackColor = true;
            this.vsCPU.Click += new System.EventHandler(this.vsCPU_Click);
            // 
            // vsPlayer
            // 
            this.vsPlayer.Location = new System.Drawing.Point(301, 106);
            this.vsPlayer.Name = "vsPlayer";
            this.vsPlayer.Size = new System.Drawing.Size(242, 58);
            this.vsPlayer.TabIndex = 2;
            this.vsPlayer.Text = "Play against a player";
            this.vsPlayer.UseVisualStyleBackColor = true;
            this.vsPlayer.Click += new System.EventHandler(this.button3_Click);
            // 
            // othello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 191);
            this.Controls.Add(this.boardSize);
            this.Controls.Add(this.vsPlayer);
            this.Controls.Add(this.vsCPU);
            this.Name = "othello";
            this.Text = "Othello";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button boardSize;
        private System.Windows.Forms.Button vsCPU;
        private System.Windows.Forms.Button vsPlayer;
    }
}