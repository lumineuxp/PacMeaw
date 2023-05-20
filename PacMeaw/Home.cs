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
            GameName.Parent = pictureBox2;
            pictureBox1.Parent = pictureBox2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Game().GameMain();
        }
    }
}
