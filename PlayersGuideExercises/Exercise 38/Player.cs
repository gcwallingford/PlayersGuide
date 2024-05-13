namespace Exercise_38;

public class Player
{
    public void MunchCookie(List<string> list, int cookieChoice)
    {
        string cookieType = list[cookieChoice];
        switch (cookieType)
        {
            case "chocolate chip":
                Console.WriteLine("This one is chocolate chip! Tasty!");
                break;
            case "oatmeal raisin":
                Console.WriteLine("This one is oatmeal raisin! Nasty!");
                break;
        }
        list.RemoveAt(cookieChoice);
    }
}

public class ComputerPlayer : Player
{
    public void ComputerPlayerChooseCookie(List<string> list)
    {
        int cookieChoice = Random.Shared.Next(list.Count);
        
    }

    public bool MunchCookie(List<string> list, int cookieChoice)
    {
        bool continueGame = true;
        string cookieType = list[cookieChoice];
        switch (cookieType)
        {
            case "chocolate chip":
                Console.WriteLine("This one is chocolate chip! Tasty!");
                continueGame = true;
                break;
            case "oatmeal raisin":
                Console.WriteLine("This one is oatmeal raisin! Nasty!");
                continueGame = false;
                break;
        }
        list.RemoveAt(cookieChoice);
        return continueGame;
    }
}