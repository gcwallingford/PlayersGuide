Recursive(0);

void Recursive(int i)
{
    if (i < 10)
    {
        Console.WriteLine(i);
        i++;
        Recursive(i);
    }
}