using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    internal class Pathfinder : IPathfinder
    {
        private const int DistanceCost = 10;
        private readonly IWorld _worldState;

        public Pathfinder(IWorld world) {
            this._worldState = world;
        }

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
