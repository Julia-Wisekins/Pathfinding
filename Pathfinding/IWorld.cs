using System.Drawing;

namespace Pathfinding
{
    internal interface IWorld
    {
        /// <summary>
        /// World Height
        /// </summary>
        int Height { get; }

        /// <summary>
        /// World Width
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Location Data
        /// </summary>
        /// <param name="position">current <see cref="Point"/></param>
        /// <returns><see cref="PathNode"/> for the provided <see cref="Point"/></returns>
        PathNode this[Point position] { get; set; }
        IEnumerable<PathNode> GetNextPositions(Point node);

        /// <summary>
        /// Closest open node to the exit
        /// </summary>
        /// <returns><see cref="PathNode"/> closest to exit</returns>
        PathNode GetLowestFValue();
    }
}
