namespace _34;

public abstract class Enemy(int enemyCurrentRow, int enemyCurrentColumn)
{
    public int EnemyCurrentRow { get; set; } = enemyCurrentRow;
    public int EnemyCurrentColumn { get; set; } = enemyCurrentColumn;
}

public class Maelstrom(int enemyCurrentRow, int enemyCurrentColumn) : Enemy(enemyCurrentRow, enemyCurrentColumn)
{
    public void MaelstromTeleportPlayer(Game game)
    {
        Direction direction = (Direction)Random.Shared.Next(0, 4);
        game.MoveRooms(direction);
    }

}

public class Amarok(int enemyCurrentRow, int enemyCurrentColumn) : Enemy(enemyCurrentRow, enemyCurrentColumn)
{
   
}