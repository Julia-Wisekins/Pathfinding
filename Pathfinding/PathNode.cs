using System.Drawing;

namespace Pathfinding
{
    /// <summary>
    /// Data about the location within the Maze
    /// </summary>
    internal class PathNode
    {
        /// <summary>
        /// an <see cref="int"/> containing the Heuristic estimate for the <see cref="Point"/> within the <see cref="IWorld"/>
        /// </summary>
        public int H { get; set; }

        /// <summary>
        /// The Lowest scoring available connected <see cref="PathNode"/>
        /// </summary>
        public PathNode ParentNode { get; set; }

        /// <summary>
        /// Whether the <see cref="PathNode"/> has already been discovered previously
        /// </summary>
        public bool Found { get; set; }
        /// <summary>
        /// Location of the node within the <see cref="IWorld"/>
        /// </summary>
        public Point Position { get; set; }
        /// <summary>
        /// Whether the <see cref="Point"/> is accessable within the <see cref="IWorld"/>
        /// </summary>
        public bool IsValidPath { get; internal set; }

        /// <summary>
        /// Whether the Heuristic estimate has already been set
        /// </summary>
        public bool Calculated { get; internal set; }

        /// <summary>
        /// calculates Heuristic estimate using Euclidean distance
        /// </summary>
        /// <param name="poition">current <see cref="Point"/></param>
        /// <param name="end">exit <see cref="Point"/></param>
        /// <param name="parent">the previous adjacent <see cref="PathNode"/></param>
        internal void CalculateFScore(Point poition, Point end, PathNode parent)
        {
            Found = true;
            var heuristicEstimate = 20;
            var h = (int)(heuristicEstimate * Math.Sqrt(Math.Pow((poition.Y - end.Y), 2) + Math.Pow((poition.X - end.X), 2)));
            if (H == 0
                || h < H)
            {
                H = h;
                ParentNode = parent;
            }
        }

        /// <summary>
        /// Wherether there are any undiscovered nodes
        /// </summary>
        /// <param name="world">Maze location</param>
        /// <returns></returns>
        internal bool HasOpenNodes(IWorld world)
        {
            return world.GetNextPositions(Position).Any(x => !x.Found);
        }
    }
}
