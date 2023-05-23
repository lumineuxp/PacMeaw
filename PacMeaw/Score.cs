using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMeaw
{
    public partial class Score : Form
    {
        public Score()
        {
            InitializeComponent();
            NumScoreLabel.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            scoretext.Parent = pictureBox1;
            pictureBox1.Parent = pictureBox4;
            pictureBox2.Parent = pictureBox4;
            RestartBtn.Parent = pictureBox4;

        }

        public void SetScore(int score)
        {
            NumScoreLabel.Text = score.ToString();
        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            new Game().GameMain();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Score_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
