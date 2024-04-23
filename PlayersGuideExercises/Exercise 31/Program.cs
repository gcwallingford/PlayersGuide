using Exercise_31;

Coordinate coordinate0 = new Coordinate();
Coordinate coordinate1 = new Coordinate(1,1);
Coordinate coordinate2 = new Coordinate(1, 0);

Console.WriteLine(coordinate0.isAdjacent(coordinate0,coordinate1));
Console.WriteLine(coordinate0.isAdjacent(coordinate1,coordinate2));
Console.WriteLine(coordinate0.isAdjacent(coordinate0,coordinate2));
