// See https://aka.ms/new-console-template for more information


using Pathfinding;
using System.Drawing;
var tiles = new int[,] {
      { 1, 0, 1 },
      { 1, 1, 1 },
      { 1, 0, 1 },
   };
IPathfinder test = new Pathfinder(new World(3, 3, tiles));

Point[] answer = test.FindPath(new System.Drawing.Point(0, 0), new System.Drawing.Point(2, 0));

if (answer.Length == 0)
{
    Console.WriteLine("No Path Found");
}

foreach (var item in answer)
{
    Console.WriteLine(item);
}
Console.ReadLine();