namespace _34;

public class Game
{
    private int _currentRow;
    private int _currentColumn;
    private bool _fountainActive;
    private bool _isGameOver;
    private readonly Cave _cave;

    public Game()
    {
        string? gameSize = StartMenu();
        switch (gameSize?.ToLower())
        {
            case "medium":
                _cave = new Cave(6);
                break;
            case "large":
                _cave = new Cave(8);
                break;
            default:
                _cave = new Cave(4);
                break;
        }
    }

    private string? StartMenu()
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
            Console.WriteLine("(Shoot) into a nearby room");

            string? input = Console.ReadLine()?.ToLower();
            GameMenuFunction(input);
        } while (_isGameOver == false);

    }

    private void DoAllDetectHazards()
    {
        DetectAdjacentPit();
        DetectInPit();
        DetectAmarok(DetectAdjacentAmarok);
        DetectAmarok(DetectIndividualAmarok);
        MaelstromDetection();
        DetectGameOver(_isGameOver);
    }

    private void GameMenuFunction(string? input)
    {
        switch (input)
        {
            case "move":
                Console.WriteLine("What direction would you like to move in?");
                MoveRooms(ConvertStringToDirection(Console.ReadLine() ?? string.Empty));
                break;
            case "enable":
                EnableFountain();
                break;
            case "leave":
                LeaveCave();
                break;
            case "shoot":
                Console.WriteLine("What direction would you like to shoot in?");
                ShootRoom(ConvertStringToDirection(Console.ReadLine() ?? string.Empty));
                break;
            default:
                Look();
                break;
        }
    }

    private void ShootRoom(Direction direction)
    {
        DetectAllEnemies(direction);
    }

    private void DetectAllEnemies(Direction aimDirection)
    {
        bool maelstrom1InRoom = EnemyInRoom(CavePositionToDirection(_cave.Maelstrom1), aimDirection);
        bool maelstrom2InRoom = EnemyInRoom(CavePositionToDirection(_cave.Maelstrom2), aimDirection);
        bool maelstrom3InRoom = EnemyInRoom(CavePositionToDirection(_cave.Maelstrom3), aimDirection);
        bool amarok1InRoom = EnemyInRoom(CavePositionToDirection(_cave.Amarok1), aimDirection);
        bool amarok2InRoom = EnemyInRoom(CavePositionToDirection(_cave.Amarok2), aimDirection);
        bool amarok3InRoom = EnemyInRoom(CavePositionToDirection(_cave.Amarok3), aimDirection);
        
        MoveEnemyOutsidePlayArea(_cave.Maelstrom1, maelstrom1InRoom);
        MoveEnemyOutsidePlayArea(_cave.Maelstrom2, maelstrom2InRoom);
        MoveEnemyOutsidePlayArea(_cave.Maelstrom3, maelstrom3InRoom);
        MoveEnemyOutsidePlayArea(_cave.Amarok1, amarok1InRoom);
        MoveEnemyOutsidePlayArea(_cave.Amarok2, amarok2InRoom);
        MoveEnemyOutsidePlayArea(_cave.Amarok3, amarok3InRoom);
    }

    private void MoveEnemyOutsidePlayArea(Enemy? enemy, bool enemyInRoom)
    {
      
        if (!enemyInRoom || enemy == null)
        {
            Console.WriteLine("Nothing seems to have changed.");
        }
        else
        {
            enemy.EnemyCurrentRow = 9;
            enemy.EnemyCurrentColumn = 9;
            Console.WriteLine("There was an enemy in that room! The room is safe now.");
        }
    }

    private bool EnemyInRoom(Direction enemyDirection, Direction aimDirection)
    {
        bool enemyInRoom = aimDirection == enemyDirection;
        return enemyInRoom;
    }

    private Direction CavePositionToDirection(Enemy? enemy)
    {
        if (enemy == null)
        {
            return Direction.Far;
        }
        
        Direction outputDirection;
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

    private void MoveRoomDenied()
    {
        Console.Clear();
        Console.WriteLine("You cannot go in that direction");
        GameMenuDisplay();
    }

    private void EnableFountain()
    {
        Console.Clear();
        if (_cave.Rooms[_currentRow, _currentColumn] == Room.Fountain)
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

    private void LeaveCave()
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

    private void Look()
    {
        Console.Clear();
        switch (_cave.Rooms[_currentRow,_currentColumn])
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

    private void DetectAdjacentPit()
    {
        var below = _currentRow + 1 == _cave.Size ? _cave.Size - 1 : _currentRow + 1;
        var right = _currentColumn + 1 == _cave.Size ? _cave.Size - 1 : _currentColumn + 1;
        var above = _currentRow - 1 < 0 ? 0 : _currentRow - 1;
        var left = _currentColumn - 1 < 0 ? 0 : _currentColumn - 1;

        if (_cave.Rooms[below, _currentColumn] == Room.Pit ||
            _cave.Rooms[_currentRow, right] == Room.Pit ||
            _cave.Rooms[above, _currentColumn] == Room.Pit ||
            _cave.Rooms[_currentRow, left] == Room.Pit)
        {
            Console.WriteLine("There is a draft in this room. There must be a pit in an adjacent room");
        }
    }

    private void DetectInPit()
    {
        if (_cave.Rooms[_currentRow, _currentColumn] == Room.Pit)
        {
            Console.Clear();
            Console.WriteLine("You've fallen into a pit and died.");
            _isGameOver = true;
        }
    }

    private void MaelstromDetection()
    {
        switch (_cave.Size)
        {
            case 4:
                DetectIndividualMaelstrom(_cave.Maelstrom1);
                break;
            case 6:
                DetectIndividualMaelstrom(_cave.Maelstrom1);
                DetectIndividualMaelstrom(_cave.Maelstrom2);
                break;
            case 8:
                DetectIndividualMaelstrom(_cave.Maelstrom1);
                DetectIndividualMaelstrom(_cave.Maelstrom2);
                DetectIndividualMaelstrom(_cave.Maelstrom3);
                break;
        }
    }

    private void DetectIndividualMaelstrom(Maelstrom? maelstrom)
    {
        if (maelstrom == null || maelstrom.EnemyCurrentRow != _currentRow || maelstrom.EnemyCurrentColumn != _currentColumn)
        {
            Console.WriteLine("There is no maelstrom in this room.");
        }
        else
        {
            maelstrom.MaelstromTeleportPlayer(this);
        }
    }

    private void DetectAmarok(Action<Amarok?> detectionMethod)
    {
        switch (_cave.Size)
        {
            case 6:
                detectionMethod(_cave.Amarok1);
                detectionMethod(_cave.Amarok2);
                break;
            case 8:
                detectionMethod(_cave.Amarok1);
                detectionMethod(_cave.Amarok2);
                detectionMethod(_cave.Amarok3);
                break;
            default:
                detectionMethod(_cave.Amarok1);
                break;
        }
    }

    private void DetectIndividualAmarok(Amarok? amarok)
    {
        if (amarok == null || amarok.EnemyCurrentRow != _currentRow || amarok.EnemyCurrentColumn != _currentColumn)
        {
            _isGameOver = false;
        }
        else
        {
            _isGameOver = true;
        }
    }

    private void DetectAdjacentAmarok(Amarok? amarok)
    {
        if (amarok != null && (amarok.EnemyCurrentRow == _currentRow || amarok.EnemyCurrentColumn == _currentColumn))
        {
            Console.WriteLine("There is a foul stench in this room. There must be an Amarok in an adjacent room");
        }
    }

    private void DetectGameOver(bool isGameOver)
    {
        if (isGameOver)
        {
            Console.WriteLine("GAME OVER");
        }
    }

    private Direction ConvertStringToDirection(string? input)
    {
        Direction output;
        input = input?.ToLower();
        switch (input)
        {
            case "south":
                output = Direction.South;
                break;
            case "east":
                output = Direction.East;
                break;
            case "west":
                output = Direction.West;
                break;
            default:
                output = Direction.North;
                break;
        }
        return output;
    }
}