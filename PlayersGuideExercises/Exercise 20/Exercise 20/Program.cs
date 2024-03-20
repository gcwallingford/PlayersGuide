using Exercise_20;

Chest chest = new();

Console.WriteLine("What would you like to do with the chest?");
ChestFunction();


void ChestFunction()
{
    var input = Console.ReadLine();
    do
    {
        switch (input)
        {
            case "Open":
                while (chest != Chest.Open)
                {
                    if (chest == Chest.Closed)
                    {
                        chest = Chest.Open;
                        Console.WriteLine("The chest is now open.");
                    }
                    else if (chest == Chest.Open)
                    {
                        Console.WriteLine("The chest is already open.");
                    }
                    else
                    {
                        Console.WriteLine("The chest is locked, and cannot be opened.");
                        break;
                    }
                }
                Console.WriteLine("What would you like to do with the chest?");
                input = Console.ReadLine();
                break;
            case "Close":
                while (chest != Chest.Closed)
                {
                    if (chest == Chest.Open)
                    {
                        chest = Chest.Closed;
                        Console.WriteLine("The chest is now closed.");
                    }
                    else if (chest == Chest.Closed)
                    {
                        Console.WriteLine("The chest is already closed.");
                    }
                    else
                    {
                        Console.WriteLine("The chest is locked, and as such, is already closed.");
                    }
                }
                Console.WriteLine("What would you like to do with the chest?");
                input = Console.ReadLine();
                break;
            case "Lock":
                while (chest != Chest.Locked)
                {
                    if (chest == Chest.Closed)
                    {
                        chest = Chest.Locked;
                        Console.WriteLine("The chest is now locked.");
                    }
                    else if (chest == Chest.Open)
                    {
                        Console.WriteLine("The chest is open, and must be closed before locking.");
                    }
                    else
                    {
                        Console.WriteLine("The chest is already locked.");
                    }
                }
                Console.WriteLine("What would you like to do with the chest?");
                input = Console.ReadLine();
                break;
        }
    } while (input != "Exit");
}