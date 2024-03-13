for (int i = 1; i < 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    { 
        Console.WriteLine("Bofa");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fire");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Lightning");
    }
    else
    {
        Console.WriteLine("Normal");
    }
}
