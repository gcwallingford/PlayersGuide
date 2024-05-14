namespace Exercise_38;

public class Player
{
    public void PlayerChooseCookie(List<string> list)
    {
        Console.WriteLine("There are " + list.Count + " cookies on the table");
        Console.WriteLine("Which cookie do you take? (1-" + list.Count + ")");
        string? input = Console.ReadLine();
        int cookieChoice = Int32.Parse(input ?? "1");
        MunchCookie(list, cookieChoice);
    }
    public void MunchCookie(List<string> list, int cookieChoice)
    {
        string cookieType = list[cookieChoice];
        switch (cookieType)
        {
            case "chocolate chip":
                Console.Clear();
                Console.WriteLine("This one is chocolate chip! Tasty!");
                break;
            case "oatmeal raisin":
                Console.Clear();
                Console.WriteLine("This one is oatmeal raisin! Nasty!");
                break;
        }
        list.RemoveAt(cookieChoice);
    }
}

public class ComputerPlayer
{
    public bool ComputerPlayerChooseCookie(List<string> list)
    {
        int cookieChoice = Random.Shared.Next(list.Count);
        bool continueGame = MunchCookie(list, cookieChoice);
        return continueGame;
    }

    public bool MunchCookie(List<string> list, int cookieChoice)
    {
        bool continueGame = true;
        string cookieType = list[cookieChoice];
        switch (cookieType)
        {
            case "chocolate chip":
                Console.Clear();
                Console.WriteLine("The computer chose chocolate chip! Tasty!");
                continueGame = true;
                break;
            case "oatmeal raisin":
                Console.Clear();
                Console.WriteLine("The computer chose oatmeal raisin. You Win!");
                continueGame = false;
                break;
        }
        list.RemoveAt(cookieChoice);
        return continueGame;
    }
}