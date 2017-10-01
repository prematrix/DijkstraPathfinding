using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace VisualPathFinder
{
    public class Pathfinder
    {
        private List<Cube> open { get; set; } // Open list for Dijkstra's pathfinding algoritm

        /// <summary>
        /// Method that checks all the possible nodes with recursion and help of the visiting method
        /// </summary>
        /// <param name="startNode">Node where to search a path from</param>
        /// <param name="_endNode">Node where to search a path to</param>
        /// <returns></returns>
        public bool FindPath(Cube _startNode, Cube _endNode)
        {
            open = new List<Cube>();
            Cube startNode = _startNode;
            Cube endNode = _endNode;
            Cube used = startNode;
            startNode.distance = 0;
            while (!Visit(used, endNode))
            {
                if (open.Count > 0)
                    used = open.Aggregate((l, r) => l.distance < r.distance ? l : r); // complicated lambda expression that selects the Cube with the smallest distance from the open list
                else
                    return false; // no path found
            }
            MakePath(startNode, endNode);
            return true; // path is found
        }
        /// <summary>
        /// Method that visits a node and checks the distance from a node to his neighbours and stores himself in them for finding back the path and returns true or false depending on if the end node is found
        /// </summary>
        /// <param name="currentNode">The node that is currently being visited</param>
        /// <param name="endNode">The node where to search a path to</param>
        /// <returns></returns>
        private bool Visit(Cube currentNode, Cube endNode)
        {
            if (currentNode == endNode) // checking if the endnode is found
            {
                return true;
            }
            if (open.Contains(currentNode)) // removing this cube from the open list
            {
                open.Remove(currentNode);
            }
            foreach (Cube myNode in currentNode.edges) // checking if the neighbours in the edge list are candidates for the path
            {
                if(myNode != null)
                {
                    if (myNode.isObstacle == false)
                    {
                        int newDistance = currentNode.distance + 10;
                        if (newDistance < myNode.distance)
                        {
                            myNode.distance = newDistance;
                            myNode.previous = currentNode;
                            open.Add(myNode);
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Method that visualizes the path by recursing back to the start node from the end node and give those Cubes a different color
        /// </summary>
        /// <param name="startNode">Node where to search a path from</param>
        /// <param name="endNode">Node where to search a path to</param>
        /// <returns></returns>
        private void MakePath(Cube startNode, Cube endNode)
        {
            Cube currentNode = endNode;
            while (currentNode != startNode)
            {
                currentNode.BackColor = Color.DarkRed;
                currentNode = currentNode.previous;
            }
            endNode.BackColor = Color.Red;
        }
    }
}
