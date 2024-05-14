namespace Exercise_38;

public class Game
{
    public Player _player = new Player();
    private ComputerPlayer _computerPlayer = new ComputerPlayer();
    
    public List<string> _list = new List<string>
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
        Console.WriteLine("For testing purposes, the oatmeal raisin is " + oatmealNumber);
        PlayGame();
    }

    public void PlayGame()
    {
        bool continueGame = true;
        do
        {
            _player.PlayerChooseCookie(_list);
            continueGame = _computerPlayer.ComputerPlayerChooseCookie(_list);
        } while (continueGame);
    }
}