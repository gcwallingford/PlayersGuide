namespace _34;

public class Cave
{
    private readonly Room[,] _rooms;
    public Room[,] Rooms => _rooms;
    private readonly int _size;
    public int Size => _size;
    public Maelstrom Maelstrom1 { get; set; }
    public Maelstrom? Maelstrom2 { get; set; }
    public Maelstrom? Maelstrom3 { get; set; }
    public Amarok Amarok1 { get; set; }
    public Amarok? Amarok2 { get; set; }
    public Amarok? Amarok3 { get; set; }
    
    
    public Cave(int size)
    { 
        _rooms = new Room[9,9];
        _size = size;
        
        switch (_size)
        {
            case 4:
                _rooms[1, 1] = Room.Pit;
                Maelstrom1 = new Maelstrom(2, 2);
                Amarok1 = new Amarok(1, 1);
                break;
            case 6:
                _rooms[4, 1] = Room.Pit;
                _rooms[1, 4] = Room.Pit;
                Maelstrom1 = new Maelstrom(2, 2);
                Maelstrom2 = new Maelstrom(3, 3);
                Amarok1 = new Amarok(3, 2);
                Amarok2 = new Amarok(2, 3);

                break;
            case 8:
                _rooms[1, 1] = Room.Pit;
                _rooms[2, 5] = Room.Pit;
                _rooms[5, 3] = Room.Pit;
                _rooms[6, 6] = Room.Pit;
                Maelstrom1 = new Maelstrom(1, 2);
                Maelstrom2 = new Maelstrom(2, 3);
                Maelstrom3 = new Maelstrom(3, 4);
                Amarok1 = new Amarok(7, 1);
                Amarok2 = new Amarok(1, 7);
                Amarok3 = new Amarok(3, 3);
                break;
            default:
                throw new ArgumentException("Invalid Size", nameof(size));
        }
        
        _rooms[0, 0] = Room.Entrance;
        PlaceFountain();
    }

    private void PlaceFountain()
    {
        int row = Random.Shared.Next(0, _size);
        int column = Random.Shared.Next(0, _size);

        if (_rooms[row, column] == Room.Entrance || _rooms[row, column] == Room.Pit)
        {
            PlaceFountain();
        }
        else
        {
            _rooms[row, column] = Room.Fountain;
        }
        Console.Clear();
        Console.WriteLine($"For testing purposes, the fountain is at ({row}, {column})");
    }
}