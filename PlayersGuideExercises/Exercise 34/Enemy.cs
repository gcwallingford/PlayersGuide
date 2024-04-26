namespace _34;

public class Enemy(int enemyCurrentRow, int enemyCurrentColumn)
{
    public int EnemyCurrentRow { get; set; }
    public int EnemyCurrentColumn { get; set; }
}

public class Maelstrom(int enemyCurrentRow, int enemyCurrentColumn) : Enemy(enemyCurrentRow, enemyCurrentColumn)
{
    public void MaelstromTeleportPlayer(Game game)
    {
        Direction direction = (Direction)Random.Shared.Next(0, 4);
        game.MoveRooms(direction);
    }
}