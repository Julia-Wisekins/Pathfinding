A* Search Algorithm 


Please be advised that this application was developed as part of a programming test, with a primary focus on demonstrating 'Good' Programming Practices. As a result, the application has been intentionally designed to showcase these practices rather than prioritize functionality typical of a business-oriented application of this scale.

Contains:
* dependency injection
* encapsulation
* Comments
* A* Pathfinding algorithm

  
How to Run –
Open the solution file named Pathfinding.sln and hit run.

Task – 
Develop a pathfinding algorithm to navigate a robot through a grid with obstacles. The goal is to find the
shortest path from a starting point to a destination point. 

1. Implement the A* or Dijkstra's algorithm to find the shortest path in the grid.
2. Optimize the solution to handle larger grids efficiently.
3. Handle edge cases such as the start or end points being on an obstacle or no possible path.

Bonus:
* Implement a visualization of the grid and the path found (using a simple console output or a
graphical library).
* Allow the user to input the grid, start, and end points. 

Assumptions – 
* Availability Consists of multiple states
* Books do not need a link to the borrower
* UI should only need the repository information

Review – 
Good Practice:
* The application is commented throughout.
* Design Patterns used: Singleton, Repository, Mediator
* Application is abstract and allows for changes to how the objects are managed and allows easy changes to where the objects are stored. Frontend could be changed easily.
* Has Descriptive Errors

Could be better:
* More testing could be added to the application. 
* No feedback on user end has been added.
* Errors Currently aren’t handled on the front end
