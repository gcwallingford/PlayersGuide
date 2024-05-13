namespace Exercise_38;

public class Game
{
    List<string> _list = new List<string>
    {
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
        "chocolate chip",
    };

    public Game()
    {
        int oatmealNumber = Random.Shared.Next(10);
        _list[oatmealNumber] = "oatmeal raisin";
    }
    
}