namespace _34;

public class Cave(int size)
{
    public Room[,] cave;
    public int Size = size;

    public Maelstrom _maelstrom1;
    public Maelstrom _maelstrom2;
    public Maelstrom _maelstrom3;
    public Amarok _amarok1;
    public Amarok _amarok2;
    public Amarok _amarok3;
    
    
    public void InitializeCave()
    {
        cave = new Room[Size,Size];

        
        switch (Size)
        {
            case 4:
                cave[1, 1] = Room.Pit;
                _maelstrom1 = new Maelstrom(2, 2);
                _amarok1 = new Amarok(1, 1);
                break;
            case 6:
                cave[4, 1] = Room.Pit;
                cave[1, 4] = Room.Pit;
                _maelstrom1 = new Maelstrom(2, 2);
                _maelstrom2 = new Maelstrom(3, 3);
                _amarok1 = new Amarok(3, 2);
                _amarok2 = new Amarok(2, 3);

                break;
            case 8:
                cave[1, 1] = Room.Pit;
                cave[2, 5] = Room.Pit;
                cave[5, 3] = Room.Pit;
                cave[6, 6] = Room.Pit;
                _maelstrom1 = new Maelstrom(1, 2);
                _maelstrom2 = new Maelstrom(2, 3);
                _maelstrom3 = new Maelstrom(3, 4);
                _amarok1 = new Amarok(7, 1);
                _amarok2 = new Amarok(1, 7);
                _amarok3 = new Amarok(3, 3);

                break;
        }
        
        cave[0, 0] = Room.Entrance;
        PlaceFountain();
    }

    public void PlaceFountain()
    {
        int row = Random.Shared.Next(0, Size);
        int column = Random.Shared.Next(0, Size);

        if (cave[row, column] == Room.Entrance || cave[row, column] == Room.Pit)
        {
            PlaceFountain();
        }
        else
        {
            cave[row, column] = Room.Fountain;
        }
        Console.Clear();
        Console.WriteLine($"For testing purposes, the fountain is at ({row}, {column})");
    }
}