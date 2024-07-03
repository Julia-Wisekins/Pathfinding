using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    internal class World : IWorld
    {
        private readonly PathNode[] _worldPositions;

        public World(int width, int height, int[,] map)
        {
            if(map == null)
            {
                // Basic override map incase none is set
                map = new int[,] {
                    { 1, 1, 1 },
                    { 1, 0, 1 },
                    { 1, 1, 1 },
                };
                width = 3;
                height = 3;
            }

            Width = width;
            Height = height;
            // Could be done with a 2D array but 1D arrays are normally quicker
            _worldPositions = new PathNode[Width * Height];
            for (int i = 0; i < _worldPositions.Length; i++)
            {
                _worldPositions[i] = new PathNode();
                _worldPositions[i].IsValidPath = map[((i / width)), (i % width)] > 0;
            }
        }

        public PathNode this[Point position] { get {
                if (position.Y >= Height
                    || position.Y < 0) {
                    return null;
                }
                if (position.X >= Width
                    || position.X < 0) {
                    return null;
                }
                return _worldPositions[(position.Y * Height) + position.X]; 
            } 
            set {
                if (position.Y >= Height
                    || position.Y < 0)
                {
                    return;
                }
                if (position.X >= Width
                    || position.X < 0)
                {
                    return;
                }
                _worldPositions[(position.Y * Height) + position.X] = value; 
            } 
        }

        public int Height { get; init; }

        public int Width { get; init; }

        public IEnumerable<PathNode> GetNextPositions(Point node)
        {
            List<PathNode> result = new List<PathNode>();

            Point tempPos = new Point(node.X - 1, node.Y);
            PathNode tempNode = this[tempPos];
            if (tempNode != null
                && tempNode.IsValidPath)
            {
                tempNode.Position = tempPos;
                result.Add(tempNode);
            }
            tempPos = new Point(node.X + 1, node.Y);
            tempNode = this[tempPos];
            if (tempNode != null
                && tempNode.IsValidPath)
            {
                tempNode.Position = tempPos;
                result.Add(tempNode);
            }
            tempPos = new Point(node.X, node.Y - 1); 
            tempNode = this[tempPos];
            if (tempNode != null
                && tempNode.IsValidPath)
            {
                tempNode.Position = tempPos;
                result.Add(tempNode); 
            }
            tempPos = new Point(node.X, node.Y + 1);
            tempNode = this[tempPos];
            if (tempNode != null
                && tempNode.IsValidPath)
            {
                tempNode.Position = tempPos;
                result.Add(tempNode);
            }
            result.RemoveAll(x => x == null);

            return result;
        }

        public PathNode GetLowestFValue()
        {
            return _worldPositions.Where(x => x.Found && x.HasOpenNodes(this)).MinBy(j => j.H);
        }
    }
}
