namespace _34;

public class Game
{
    private Cave _cave = new Cave();
    private int _currentRow;
    private int _currentColumn;
    private bool _fountainActive;

    public void MenuDisplay()
    {
        Console.WriteLine($"You are in room ({_currentRow}, {_currentColumn})");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("(Move) rooms");
        Console.WriteLine("(Enable) the fountain");
        Console.WriteLine("(Look) around the room");
        Console.WriteLine("(Leave) the cave");
        
        string? input = Console.ReadLine()?.ToLower();
        MenuFunction(input);
    }

    public void MenuFunction(string? input)
    {
        switch (input)
        {
            case "move":
                Console.WriteLine("What direction would you like to move in?");
                string direction = Console.ReadLine().ToLower();
                MoveRooms(direction);
                break;
            case "enable":
                EnableFountain();
                break;
            case "leave":
                LeaveCave();
                break;
            case "look":
                Look();
                break;
        }
    }

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
                    MoveRoomDenied();
                }
                break;
            case "south":
                if (_currentRow < 3)
                {
                    _currentRow++;
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
            case "east":
                if (_currentColumn < 3)
                {
                    _currentColumn++;
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
            case "west" :
                if (_currentColumn > 0)
                {
                    _currentColumn--;
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
        }

        Console.Clear();
        MenuDisplay();
    }

    public void MoveRoomDenied()
    {
        Console.Clear();
        Console.WriteLine("You cannot go in that direction");
        MenuDisplay();
    }

    public void EnableFountain()
    {
        Console.Clear();
        if (_cave.cave[_currentRow, _currentColumn] == Room.Fountain)
        {
            _fountainActive = true;
            Console.WriteLine("The fountain is now active.");
        }
        else
        {
            Console.WriteLine("You must find the fountain first!");
        }
        MenuDisplay();
    }
    
    public void LeaveCave()
    {
        if (_fountainActive)
        {
            Console.WriteLine("You enabled the fountain, and escaped with your life!");
        }
        else
        {
            Console.WriteLine("You can't leave without enabling the fountain!");
        }
    }

    public void Look()
    {
        Console.Clear();
        switch (_cave.cave[_currentRow,_currentColumn])
        {
            case Room.Entrance:
                Console.WriteLine("You can see the light of the entrance.");
                break;
            case Room.Fountain:
                Console.WriteLine("You can see the empty fountain.");
                break;
            case Room.Empty:
                Console.WriteLine("There is nothing of note in this room.");
                break;
        }
        
        MenuDisplay();
    }
}