using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualPathFinder
{
    public partial class MainForm : Form
    {
        private Panel drawingPanel { get; set; }

        public delegate void currentColor(Color col);
        public event currentColor ss;
        public MainForm()
        {
            InitializeComponent();
            drawingPanel = new Panel();
            drawingPanel.Location = new Point(0, 0);
            drawingPanel.Size = new Size(40 * 12, 40 * 12);
            Controls.Add(drawingPanel);
            DrawField();
        }

        public void Process()
        {
            ss(Color.Green);
        }

        private void DrawField()
        {
            Cube[,] myCubes = new Cube[15, 15]; 
            for(int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    Point loc = new Point(x * 40, y * 40);
                    Cube workingCube = new Cube(loc, this);
                    drawingPanel.Controls.Add(workingCube);
                }
            }
        }

        private void newFieldBtn_Click(object sender, EventArgs e)
        {
            Process();
        }
    }
}
