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

        }

        private void RestartBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            new Game().GameMain();
        }
        
    }
}
