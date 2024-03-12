Console.WriteLine("The following items are available:");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");
Console.WriteLine("Which item number do you wish to know the price of?");
string item = null;
string price = null;

switch (Convert.ToInt32(Console.ReadLine()))
{
    case 1:
        item = "Rope";
        price = "2";
        break;
    case 2:
        item = "Torches";
        price = "1";
        break;
    case 3:
        item = "Climbing Equipment";
        price = "5";
        break;
    case 4:
        item = "Clean Water";
        price = "2";
        break;
    case 5:
        item = "Machete";
        price = "5";
        break;
    case 6:
        item = "Canoe";
        price = "10";
        break;
    case 7:
        item = "Food Supplies";
        price = "4";
        break;
}

Console.WriteLine(item + " will cost " + price + " gold.");