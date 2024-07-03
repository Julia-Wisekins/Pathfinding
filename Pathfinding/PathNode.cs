using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    internal class PathNode
    {
        public int H { get; set; }
        public PathNode ParentNode { get; set; }
        public bool Found { get; set; }
        public Point Position { get; set; }
        public bool IsValidPath { get; internal set; }
        public bool Calculated { get; internal set; }

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

        internal bool HasOpenNodes(IWorld world)
        {
            return world.GetNextPositions(Position).Any(x => !x.Found);
        }
    }
}
