using System.Drawing;

namespace Pathfinding
{
    /// <summary>
    /// The State of the Maze
    /// </summary>
    internal class World : IWorld
    {
        private readonly PathNode[] _worldPositions;

        /// <summary>
        /// initializes world locations and map
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="map"></param>
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

        /// <summary>
        /// Location Data
        /// </summary>
        /// <param name="position">current <see cref="Point"/></param>
        /// <returns><see cref="PathNode"/> for the provided <see cref="Point"/></returns>
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
        /// <summary>
        /// Maze Height
        /// </summary>
        public int Height { get; init; }

        /// <summary>
        /// Maze Width
        /// </summary>
        public int Width { get; init; }

        /// <summary>
        /// The <see cref="Point"/>'s  avalible travel paths from the provided <see cref="Point"/>
        /// </summary>
        /// <param name="node"></param>
        /// <returns>avalible <see cref="Point"/></returns>
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

        /// <summary>
        /// Closest open node to the exit
        /// </summary>
        /// <returns><see cref="PathNode"/> closest to exit</returns>
        public PathNode GetLowestFValue()
        {
            return _worldPositions.Where(x => x.Found && x.HasOpenNodes(this)).MinBy(j => j.H);
        }
    }
}
