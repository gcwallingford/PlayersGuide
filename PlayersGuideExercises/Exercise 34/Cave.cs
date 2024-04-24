namespace _34;

public class Cave
{
    public Room[,] cave = new Room[4,4];
    public Cave()
    {
        for (int rows = 0; rows < 3; rows++)
        {
            for (int columns = 0; columns < 3; columns++)
            {
                cave[rows, columns] = Room.Empty;
            }
        }
        
        cave[0, 0] = Room.Entrance;
        PlaceFountain();
    }

    public void PlaceFountain()
    {
        int row = Random.Shared.Next(0, 3);
        int column = Random.Shared.Next(0, 3);

        if (cave[row, column] == Room.Entrance)
        {
            PlaceFountain();
        }
        else
        {
            cave[row, column] = Room.Fountain;
        }
    }
}