using System.Security.Cryptography.X509Certificates;

namespace _34;

public class Game
{
    private int _currentRow;
    private int _currentColumn;
    private bool _fountainActive;
    private bool _isGameOver;
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
        do
        {
            DoAllDetectHazards();
            Console.WriteLine($"You are in room ({_currentRow}, {_currentColumn})");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("(Move) rooms");
            Console.WriteLine("(Enable) the fountain");
            Console.WriteLine("(Look) around the room");
            Console.WriteLine("(Leave) the cave");

            string? input = Console.ReadLine()?.ToLower();
            GameMenuFunction(input);
        } while (_isGameOver == false);

    }

    public void DoAllDetectHazards()
    {
        DetectAdjacentPit();
        DetectInPit();
        AdjacentAmarokDetection();
        AmarokDetection(); 
        MaelstromDetection();
        DetectGameOver(_isGameOver);
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
            case "shoot":
                Console.WriteLine("What direction would you like to shoot in?");
                ShootRoom(ConvertStringToDirection(Console.ReadLine()));
                break;
        }
    }

    private void ShootRoom(Direction direction)
    {
        DetectAllEnemies(direction);
    }

    private void DetectAllEnemies(Direction aimDirection)
    {
        bool maelstrom1InRoom = EnemyInRoom(CavePositionToDirection(_cave._maelstrom1), aimDirection);
        bool maelstrom2InRoom = EnemyInRoom(CavePositionToDirection(_cave._maelstrom2), aimDirection);
        bool maelstrom3InRoom = EnemyInRoom(CavePositionToDirection(_cave._maelstrom3), aimDirection);
        bool amarok1InRoom = EnemyInRoom(CavePositionToDirection(_cave._amarok1), aimDirection);
        bool amarok2InRoom = EnemyInRoom(CavePositionToDirection(_cave._amarok2), aimDirection);
        bool amarok3InRoom = EnemyInRoom(CavePositionToDirection(_cave._amarok3), aimDirection);
        if (maelstrom1InRoom == true)
        {
            _cave._maelstrom1.EnemyCurrentRow = 9;
            _cave._maelstrom1.EnemyCurrentColumn = 9;
        }
        if (maelstrom2InRoom == true)
        {
            _cave._maelstrom2.EnemyCurrentRow = 9;
            _cave._maelstrom2.EnemyCurrentColumn = 9;
        }
        if (maelstrom3InRoom == true)
        {
            _cave._maelstrom3.EnemyCurrentRow = 9;
            _cave._maelstrom3.EnemyCurrentColumn = 9;
        }
        if (amarok1InRoom == true)
        {
            _cave._amarok1.EnemyCurrentRow = 9;
            _cave._amarok1.EnemyCurrentColumn = 9;
        }
        if (amarok2InRoom == true)
        {
            _cave._amarok2.EnemyCurrentRow = 9;
            _cave._amarok2.EnemyCurrentColumn = 9;
        }
        if (amarok3InRoom == true)
        {
            _cave._amarok3.EnemyCurrentRow = 9;
            _cave._amarok3.EnemyCurrentColumn = 9;
        }
    }
    
    

    private bool EnemyInRoom(Direction enemyDirection, Direction aimDirection)
    {
        bool enemyInRoom = aimDirection == enemyDirection;
        return enemyInRoom;
    }

    private Direction CavePositionToDirection(Enemy enemy)
    {
        Direction outputDirection = Direction.North;
        if (enemy.EnemyCurrentRow == _currentRow && enemy.EnemyCurrentColumn == _currentColumn - 1)
        {
            outputDirection = Direction.North;
        }
        else if (enemy.EnemyCurrentRow == _currentRow && enemy.EnemyCurrentColumn == _currentColumn + 1)
        {
            outputDirection = Direction.South;
        }
        else if (enemy.EnemyCurrentRow == _currentRow - 1 && enemy.EnemyCurrentColumn == _currentColumn)
        {
            outputDirection = Direction.West;
        }
        else if (enemy.EnemyCurrentRow == _currentRow + 1 && enemy.EnemyCurrentColumn == _currentColumn)
        {
            outputDirection = Direction.East;
        }
        else
        {
            outputDirection = Direction.Far;
        }

        return outputDirection;
    }

    public void MoveRooms(Direction direction)
    {
        switch ((int)direction)
        {
            case 0:
                if (_currentRow > 0)
                {
                    _currentRow--;
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
        var below = _currentRow + 1 == _cave.Size ? _cave.Size - 1 : _currentRow + 1;
        var right = _currentColumn + 1 == _cave.Size ? _cave.Size - 1 : _currentColumn + 1;
        var above = _currentRow - 1 < 0 ? 0 : _currentRow - 1;
        var left = _currentColumn - 1 < 0 ? 0 : _currentColumn - 1;

        if (_cave.cave[below, _currentColumn] == Room.Pit ||
            _cave.cave[_currentRow, right] == Room.Pit ||
            _cave.cave[above, _currentColumn] == Room.Pit ||
            _cave.cave[_currentRow, left] == Room.Pit)
        {
            Console.WriteLine("There is a draft in this room. There must be a pit in an adjacent room");
        }
    }

    public void DetectInPit()
    {
        if (_cave.cave[_currentRow, _currentColumn] == Room.Pit)
        {
            Console.Clear();
            Console.WriteLine("You've fallen into a pit and died.");
            _isGameOver = true;
        }
    }

    public void MaelstromDetection()
    {
        switch (_cave.Size)
        {
            case 4:
                DetectIndividualMaelstrom(_cave._maelstrom1);

                break;
            case 6:
                DetectIndividualMaelstrom(_cave._maelstrom1);
                DetectIndividualMaelstrom(_cave._maelstrom2);
                break;
            case 8:
                DetectIndividualMaelstrom(_cave._maelstrom1);
                DetectIndividualMaelstrom(_cave._maelstrom2);
                DetectIndividualMaelstrom(_cave._maelstrom3);
                break;
        }
    }
    
    public void DetectIndividualMaelstrom(Maelstrom maelstrom)
    {
        if (maelstrom.EnemyCurrentRow == _currentRow && maelstrom.EnemyCurrentColumn == _currentColumn)
        {
            maelstrom.MaelstromTeleportPlayer(this);
        }
        else
        {
            Console.WriteLine("There is no maelstrom in this room.");
        }
    }

    public void AmarokDetection()
    {
        switch (_cave.Size)
        {
            case 4:
                DetectIndividualAmarok(_cave._amarok1);
                break;
            case 6:
                DetectIndividualAmarok(_cave._amarok1);
                DetectIndividualAmarok(_cave._amarok2);
                break;
            case 8:
                DetectIndividualAmarok(_cave._amarok1);
                DetectIndividualAmarok(_cave._amarok2);
                DetectIndividualAmarok(_cave._amarok3);
                break;
        }
    }
    public void DetectIndividualAmarok(Amarok amarok)
    {
        if (amarok.EnemyCurrentRow == _currentRow && amarok.EnemyCurrentColumn == _currentColumn)
        {
            _isGameOver = true;
        }
        else
        {
            _isGameOver = false;
        }
    }

    public void DetectAdjacentAmarok(Amarok amarok)
    {
        if (amarok.EnemyCurrentRow == _currentRow || amarok.EnemyCurrentColumn == _currentColumn)
        {
            Console.WriteLine("There is a foul stench in this room. There must be an Amarok in an adjacent room");
        }
    }
    
    public void AdjacentAmarokDetection()
    {
        switch (_cave.Size)
        {
            case 4:
                DetectAdjacentAmarok(_cave._amarok1);
                break;
            case 6:
                DetectAdjacentAmarok(_cave._amarok1);
                DetectAdjacentAmarok(_cave._amarok2);
                break;
            case 8:
                DetectAdjacentAmarok(_cave._amarok1);
                DetectAdjacentAmarok(_cave._amarok2);
                DetectAdjacentAmarok(_cave._amarok3);
                break;
        }
    }

    public void DetectGameOver(bool isGameOver)
    {
        if (isGameOver)
        {
            Console.WriteLine("GAME OVER");
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