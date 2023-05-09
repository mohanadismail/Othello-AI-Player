using OthelloAI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace OthelloAI
{
    public partial class boardWindow : Form
    {
        public boardWindow()
        {
            InitializeComponent();
        }

        private void boardWindow_Load(object sender, EventArgs e)
        {
            string selectedFileName = "background.png";
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);

                    button.Image = Properties.Resources.empty;
                    boardLayout.Controls.Add(button, column, row);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void turnLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
