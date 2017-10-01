using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualPathFinder
{
    public partial class MainForm : Form
    {
        public ObstacleType selectedType { get; set; } // easy access to the selectedType for the Cubes
        public Cube startPoint { get; set; } // selected startPoint Cube
        public Cube endPoint { get; set; } // selected endPoint Cube
        private Cube[,] myCubes { get; set; } // 2d cube array for mapping when building
        public MainForm()
        {
            InitializeComponent();
            drawingPanel.Size = new Size(40 * 12, 40 * 12);
            DrawField();
            InitItems();
        }
        /// <summary>
        /// Method that adds the Obstacle Enum Types to the listBox
        /// </summary>
        private void InitItems()
        {
            optionBox.Items.Add(ObstacleType.START);
            optionBox.Items.Add(ObstacleType.END);
            optionBox.Items.Add(ObstacleType.OBSTACLE);
            optionBox.Items.Add(ObstacleType.NONE);
        }

        /// <summary>
        /// Method that draws the field
        /// </summary>
        private void DrawField()
        {
            myCubes = new Cube[24, 24]; 
            for(int y = 0; y < 24; y++)
            {
                for (int x = 0; x < 24; x++)
                {
                    Point loc = new Point(x * 20, y *20);
                    Cube workingCube = new Cube(loc, this);
                    drawingPanel.Controls.Add(workingCube);
                    myCubes[y, x] = workingCube;

                    if(x > 0)
                        workingCube.edges.Add(myCubes[y, x -1]);
                    if (y > 0)
                        workingCube.edges.Add(myCubes[y - 1, x]);
                }
            }
            foreach(Cube s in myCubes)
            {
                if (s != null)
                    s.NotifyEdges();
            }
        }

        /// <summary>
        /// Method that resets the field when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newFieldBtn_Click(object sender, EventArgs e)
        {
            startPoint = null;
            endPoint = null;
            foreach (Cube s in myCubes)
            {
                s.isObstacle = false;
                s.distance = int.MaxValue;
                s.previous = null;
                s.BackColor = Color.Gray;
            }
        }

        /// <summary>
        /// Method that changes the selected type to the right selected item from the Listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = (ObstacleType)optionBox.SelectedItem;
        }

        /// <summary>
        /// Method that creates a instance of the pathfinder and let it find a path using the start and endpoint when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findPathBtn_Click(object sender, EventArgs e)
        {
            Pathfinder workingFinder = new Pathfinder();
            if (!workingFinder.FindPath(startPoint, endPoint))
                MessageBox.Show("No path has been found!");
        }
    }
}
