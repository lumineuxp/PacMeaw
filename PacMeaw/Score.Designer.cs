namespace PacMeaw
{
    partial class Score
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Score));
            LevelLabel = new System.Windows.Forms.Label();
            ScoreLabel = new System.Windows.Forms.Label();
            NumScoreLabel = new System.Windows.Forms.Label();
            RestartBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            LevelLabel.Location = new System.Drawing.Point(290, 9);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Size = new System.Drawing.Size(193, 59);
            LevelLabel.TabIndex = 0;
            LevelLabel.Text = "Level 1";
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.Font = new System.Drawing.Font("Showcard Gothic", 25.8000011F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ScoreLabel.Location = new System.Drawing.Point(238, 159);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new System.Drawing.Size(188, 54);
            ScoreLabel.TabIndex = 1;
            ScoreLabel.Text = "Score :";
            // 
            // NumScoreLabel
            // 
            NumScoreLabel.Font = new System.Drawing.Font("Showcard Gothic", 25.8000011F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            NumScoreLabel.Location = new System.Drawing.Point(432, 159);
            NumScoreLabel.Name = "NumScoreLabel";
            NumScoreLabel.Size = new System.Drawing.Size(133, 54);
            NumScoreLabel.TabIndex = 2;
            NumScoreLabel.Text = "0";
            // 
            // RestartBtn
            // 
            RestartBtn.BackColor = System.Drawing.Color.Transparent;
            RestartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            RestartBtn.FlatAppearance.BorderSize = 0;
            RestartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RestartBtn.Image = (System.Drawing.Image)resources.GetObject("RestartBtn.Image");
            RestartBtn.Location = new System.Drawing.Point(323, 300);
            RestartBtn.Name = "RestartBtn";
            RestartBtn.Size = new System.Drawing.Size(114, 118);
            RestartBtn.TabIndex = 3;
            RestartBtn.UseVisualStyleBackColor = false;
            RestartBtn.Click += RestartBtn_Click;
            // 
            // Score
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(RestartBtn);
            Controls.Add(NumScoreLabel);
            Controls.Add(ScoreLabel);
            Controls.Add(LevelLabel);
            Name = "Score";
            Text = "Score";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label NumScoreLabel;
        private System.Windows.Forms.Button RestartBtn;
    }
}