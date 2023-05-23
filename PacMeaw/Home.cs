using GameLib;
using SFML.Graphics;
using SFML.System;
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
    public partial class Home : Form
    {


        public Home()
        {
            InitializeComponent();
            GameName.Parent = pictureBox3;
            button1.Parent = pictureBox3;
            pictureBox2.Parent = pictureBox3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            //new Game().GameMain();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Game().GameMain();
        }

        private void GameName_Click_1(object sender, EventArgs e)
        {

        }

        private void GameName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
