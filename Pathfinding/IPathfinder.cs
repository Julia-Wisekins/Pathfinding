using System.Drawing;

namespace Pathfinding
{
    internal interface IPathfinder
    {
        /// <summary>
        /// Finds Optimal Path
        /// </summary>
        /// <param name="startLocation"> current <see cref="Point"/> </param>
        /// <param name="endLocation"> exit <see cref="Point"/></param>
        /// <returns>Most effient Path</returns>
        Point[] FindPath(Point startLocation, Point endLocation);
    }
}
