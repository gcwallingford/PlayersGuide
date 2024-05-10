void IntTryParseLoop(string? input)
{
    if (input != null)
    {
        int.TryParse(input, out int result);
    }
    else
    {
        input = Console.ReadLine();
        IntTryParseLoop(input);
    }
}

string? numberString = Console.ReadLine();
IntTryParseLoop(numberString);