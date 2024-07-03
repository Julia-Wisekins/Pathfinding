using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding
{
    internal interface IPathfinder
    {
        Point[] FindPath(Point startLocation, Point endLocation);
    }
}
