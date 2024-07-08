using System.Drawing;

namespace Pathfinding
{
    internal class Pathfinder : IPathfinder
    {
        private const int DistanceCost = 10;
        private readonly IWorld _worldState;

        /// <summary>
        /// initializes world to find most efficient hiking trails for robots
        /// </summary>
        /// <param name="world">Maze</param>
        public Pathfinder(IWorld world) {
            this._worldState = world;
        }

        /// <summary>
        /// Finds Optimal Robot Hiking Path
        /// </summary>
        /// <param name="startLocation"> current <see cref="Point"/> within <see cref="World"/></param>
        /// <param name="endLocation"> exit <see cref="Point"/> within <see cref="World"/></param>
        /// <returns>Google maps instructions of most efficient hiking trail</returns>
        public Point[] FindPath(Point startLocation, Point endLocation)
        {
            Queue<Point> path = new Queue<Point>();
            Point currentLocation = startLocation;
            bool foundEnd = false;

            try
            {
                while (currentLocation != endLocation)
                {
                    foreach (PathNode location in _worldState.GetNextPositions(currentLocation))
                    {
                        location.CalculateFScore(location.Position, endLocation, _worldState[currentLocation]);
                        if (location.Position == endLocation)
                        {
                            foundEnd = true;
                            break;
                        }
                    }
                    if (foundEnd)
                    {
                        break;
                    }
                    PathNode lowestLocation = _worldState.GetLowestFValue();
                    if (lowestLocation == null) { 
                        // No nodes remain
                        return new Point[0];
                    }
                    currentLocation = lowestLocation.Position;
                }
            }
            catch (Exception ex) { 
                // If we have an error here we did not find a solution and have checked every node available
                return new Point[0];
            }

            PathNode currentNode = _worldState[endLocation];
            currentLocation = currentNode.Position;

            while (currentNode != null) {
                path.Enqueue(currentLocation);
                if (currentLocation == startLocation) {
                    break;
                }
                currentNode = currentNode.ParentNode;
                currentLocation = currentNode.Position;
            }

            return path.Reverse().ToArray();
        }
    }
}
