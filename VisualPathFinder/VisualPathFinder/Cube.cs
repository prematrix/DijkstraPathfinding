using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace VisualPathFinder
{
    public class Cube : PictureBox
    {
        private MainForm thisGame { get; set; } // instance of the mainform for easy, but ugly access
        public List<Cube> edges { get; set; } // list that contains all the cubes next to this cube
        public int distance { get; set; } // ugly integer for pathfinding // the distance from the start cube to this cube
        public Cube previous { get; set; } // ugly property for pathfinding // the cube that found this cube first
        public bool isObstacle { get; set; } // ugly bool that says if the pathfinding can use this cube in the path or not

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="myGame"></param>
        public Cube(Point loc, MainForm myGame)
        {
            isObstacle = false;
            distance = int.MaxValue / 2;
            thisGame = myGame;
            Location = loc;
            Size = new Size(20, 20);
            BackColor = Color.Gray;
            edges = new List<Cube>();
            MouseDown += Click_action;
        }

        /// <summary>
        /// Method that is triggered on the mouse down event. It checks and sets the values for what 
        /// sort of cube this will be in the simulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_action(object sender, EventArgs e)
        {
            if (thisGame.selectedType == ObstacleType.START)
            {
                if (thisGame.startPoint != null)
                    thisGame.startPoint.BackColor = Color.Gray;
                thisGame.startPoint = this;
                BackColor = Color.Green;
            }
            else if (thisGame.selectedType == ObstacleType.END)
            {
                if (thisGame.endPoint != null)
                    thisGame.endPoint.BackColor = Color.Gray;
                thisGame.endPoint = this;
                BackColor = Color.Red;
            }
            else if (thisGame.selectedType == ObstacleType.OBSTACLE)
            {
                BackColor = Color.Blue;
                isObstacle = true;
            }
            else if (thisGame.selectedType == ObstacleType.NONE)
            {
                BackColor = Color.Gray;
                isObstacle = false;
            }
        }

        /// <summary>
        /// Method that is used to notify this cube neighbours that they need this cube as a neighbour too
        /// </summary>
        public void NotifyEdges()
        {
            foreach(Cube s in edges)
            {
                if (!s.edges.Contains(this))
                {
                    s.edges.Add(this);
                }
            }
        }
    }
}
