using System.Security.Cryptography.X509Certificates;

namespace _34;

public class Game
{
    
    private int _currentRow;
    private int _currentColumn;
    private bool _fountainActive;
    private Cave _cave;

    public Game()
    {
        string? gameSize = StartMenu();
        switch (gameSize.ToLower())
        {
            case "small":
                _cave = new Cave(4);
                _cave.InitializeCave();
                break;
            case "medium":
                _cave = new Cave(6);
                _cave.InitializeCave();
                break;
            case "large":
                _cave = new Cave(8);
                _cave.InitializeCave();
                break;
        }
    }

    public string? StartMenu()
    {
        Console.WriteLine("Would you like to play a");
        Console.WriteLine("Small World");
        Console.WriteLine("Medium World");
        Console.WriteLine("Large World");
        string? input = Console.ReadLine();
        return input;
    }

    public void GameMenuDisplay()
    {
        Console.WriteLine($"You are in room ({_currentRow}, {_currentColumn})");
        DetectAdjacentPit();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("(Move) rooms");
        Console.WriteLine("(Enable) the fountain");
        Console.WriteLine("(Look) around the room");
        Console.WriteLine("(Leave) the cave");
        
        string? input = Console.ReadLine()?.ToLower();
        GameMenuFunction(input);
    }

    public void GameMenuFunction(string? input)
    {
        switch (input)
        {
            case "move":
                Console.WriteLine("What direction would you like to move in?");
                MoveRooms(ConvertStringToDirection(Console.ReadLine()));
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

    public void MoveRooms(Direction direction)
    {
        switch ((int)direction)
        {
            case 0:
                if (_currentRow > 0)
                {
                    _currentRow--;
                    DetectInPit();
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
            case 1:
                if (_currentRow < _cave.Size)
                {
                    _currentRow++;
                    DetectInPit();
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
            case 2:
                if (_currentColumn < _cave.Size)
                {
                    _currentColumn++;
                    DetectInPit();
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
            case 3 :
                if (_currentColumn > 0)
                {
                    _currentColumn--;
                    DetectInPit();
                }
                else
                {
                    MoveRoomDenied();
                }
                break;
        }

        Console.Clear();
        GameMenuDisplay();
    }

    public void MoveRoomDenied()
    {
        Console.Clear();
        Console.WriteLine("You cannot go in that direction");
        GameMenuDisplay();
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
        GameMenuDisplay();
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
        
        GameMenuDisplay();
    }

    public void DetectAdjacentPit()
    {
        if (_cave.cave[++_currentRow, _currentColumn] == Room.Pit ||
            _cave.cave[_currentRow, ++_currentColumn] == Room.Pit ||
            _cave.cave[--_currentRow, _currentColumn] == Room.Pit ||
            _cave.cave[_currentRow, --_currentColumn] == Room.Pit)
        {
            Console.WriteLine("There is a draft in this room. There must be a pit in an adjacent room");
        }
    }

    public void DetectInPit()
    {
        if (_cave.cave[_currentRow, _currentColumn] == Room.Pit)
        {
            Console.Clear();
            Console.WriteLine("You've fallen into a pit and died. Game Over.");
        }
    }

    public void DetectMaelstrom(Maelstrom maelstrom)
    {
        if (maelstrom.EnemyCurrentRow == _currentRow && maelstrom.EnemyCurrentColumn == _currentColumn)
        {
            maelstrom.MaelstromTeleportPlayer(this);
        }
    }

    public Direction ConvertStringToDirection(string input)
    {
        Direction output = Direction.North;
        input.ToLower();
        switch (input)
        {
            case "north":
                output = Direction.North;
                break;
            case "south":
                output = Direction.South;
                break;
            case "east":
                output = Direction.East;
                break;
            case "west":
                output = Direction.West;
                break;
        }
        return output;
    }

    public bool AdjacentRoomPit()
    {
        int size = _cave.Size;
        bool pitNearRoom = false;
        if (_currentRow == 0)
        {
            if (_cave.cave[++_currentRow, _currentColumn] == Room.Pit ||
                _cave.cave[_currentRow, ++_currentColumn] == Room.Pit ||
                _cave.cave[_currentRow, --_currentColumn] == Room.Pit)
            {
                pitNearRoom = true;
            }
        }

        if (_currentRow == size)
        {
            if (_cave.cave[_currentRow, ++_currentColumn] == Room.Pit ||
                _cave.cave[_currentRow, --_currentColumn] == Room.Pit ||
                _cave.cave[--_currentRow, _currentColumn] == Room.Pit)
            {
                pitNearRoom = true;
            }
        }
        
        if (_currentColumn == 0)
        {
            if (_cave.cave[_currentRow, ++_currentColumn] == Room.Pit ||
                _cave.cave[++_currentRow, _currentColumn] == Room.Pit ||
                _cave.cave[--_currentRow, _currentColumn] == Room.Pit)
            {
                pitNearRoom = true;
            }
        }
        
        if (_currentColumn == size)
        {
            if (_cave.cave[_currentRow, --_currentColumn] == Room.Pit ||
                _cave.cave[++_currentRow, _currentColumn] == Room.Pit ||
                _cave.cave[--_currentRow, _currentColumn] == Room.Pit)
            {
                pitNearRoom = true;
            }
        }
        return pitNearRoom;
    }
}