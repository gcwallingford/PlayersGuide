namespace _34;

public class Game
{
    private Cave _cave = new Cave();
    private int _currentRow = 0;
    private int _currentColumn = 0;
    private bool _fountainActive = false;

    public void MoveRooms(string direction)
    {
        switch (direction)
        {
            case "north":
                if (_currentRow > 0)
                {
                    _currentRow--;
                }
                else
                {
                    Console.WriteLine("You cannot go in that direction");
                }
                break;
            case "south":
                if (_currentRow < 3)
                {
                    _currentRow++;
                }
                else
                {
                    Console.WriteLine("You cannot go in that direction");
                }
                break;
            case "east":
                if (_currentColumn < 3)
                {
                    _currentColumn++;
                }
                else
                {
                    Console.WriteLine("You cannot go in that direction");
                }
                break;
            case "west" :
                if (_currentColumn > 0)
                {
                    _currentColumn--;
                }
                else
                {
                    Console.WriteLine("You cannot go in that direction");
                }
                break;
        }
        return;
    }

    public bool EnableFountain()
    {
        if (_cave.cave[_currentRow, _currentColumn] == Room.Fountain)
        {
            _fountainActive = true;
        }
        else
        {
            Console.WriteLine("You must find the fountain first!");
        }

        return _fountainActive;
    }
}