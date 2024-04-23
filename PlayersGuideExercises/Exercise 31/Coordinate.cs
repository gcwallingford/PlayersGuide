namespace Exercise_31;

public struct Coordinate(int column = 0 , int row = 0)
{
    private int _row = row;
    private int _column = column;

    public bool isAdjacent(Coordinate coordinate1, Coordinate coordinate2)
    {
        bool coordinateAdjacent;
        if (coordinate1._column == coordinate2._column + 1 || coordinate1._column == coordinate2._column - 1 || coordinate1._row == coordinate2._row + 1 || coordinate1._row == coordinate2._row - 1)
        {
            coordinateAdjacent = true;
        }
        else
        {
            coordinateAdjacent = false;
        }

        return coordinateAdjacent;
    }
}