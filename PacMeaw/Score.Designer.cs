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
            NumScoreLabel = new System.Windows.Forms.Label();
            RestartBtn = new System.Windows.Forms.Button();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            scoretext = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // NumScoreLabel
            // 
            NumScoreLabel.BackColor = System.Drawing.Color.Transparent;
            NumScoreLabel.Font = new System.Drawing.Font("Berlin Sans FB", 25.8000011F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NumScoreLabel.ForeColor = System.Drawing.SystemColors.Info;
            NumScoreLabel.Location = new System.Drawing.Point(237, 213);
            NumScoreLabel.Name = "NumScoreLabel";
            NumScoreLabel.Size = new System.Drawing.Size(300, 53);
            NumScoreLabel.TabIndex = 2;
            NumScoreLabel.Text = "0";
            // 
            // RestartBtn
            // 
            RestartBtn.BackColor = System.Drawing.Color.Transparent;
            RestartBtn.BackgroundImage = Properties.Resources.replay;
            RestartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            RestartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            RestartBtn.FlatAppearance.BorderSize = 0;
            RestartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            RestartBtn.Location = new System.Drawing.Point(255, 487);
            RestartBtn.Name = "RestartBtn";
            RestartBtn.Size = new System.Drawing.Size(232, 64);
            RestartBtn.TabIndex = 3;
            RestartBtn.UseVisualStyleBackColor = false;
            RestartBtn.Click += RestartBtn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            pictureBox2.Image = Properties.Resources.home;
            pictureBox2.Location = new System.Drawing.Point(170, 487);
            pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(78, 64);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // scoretext
            // 
            scoretext.AutoSize = true;
            scoretext.BackColor = System.Drawing.Color.Transparent;
            scoretext.Font = new System.Drawing.Font("Berlin Sans FB Demi", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            scoretext.ForeColor = System.Drawing.Color.PapayaWhip;
            scoretext.Location = new System.Drawing.Point(237, 149);
            scoretext.Name = "scoretext";
            scoretext.Size = new System.Drawing.Size(157, 45);
            scoretext.TabIndex = 7;
            scoretext.Text = "SCORE :";
            scoretext.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = Properties.Resources.tableScore;
            pictureBox1.Location = new System.Drawing.Point(94, 51);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(454, 429);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = System.Drawing.Color.Transparent;
            pictureBox3.Image = Properties.Resources.pngwing_com_3;
            pictureBox3.Location = new System.Drawing.Point(46, 109);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(184, 229);
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.Transparent;
            pictureBox4.Image = Properties.Resources._45908;
            pictureBox4.Location = new System.Drawing.Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(775, 599);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // Score
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.AppWorkspace;
            ClientSize = new System.Drawing.Size(653, 599);
            Controls.Add(pictureBox3);
            Controls.Add(scoretext);
            Controls.Add(pictureBox2);
            Controls.Add(RestartBtn);
            Controls.Add(NumScoreLabel);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox4);
            Name = "Score";
            Text = "Score";
            Load += Score_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label NumScoreLabel;
        private System.Windows.Forms.Button RestartBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label scoretext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}