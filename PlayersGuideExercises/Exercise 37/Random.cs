namespace Exercise_37;

public static class Random
{
    public static double NextDouble(double maxValue)
    {
        System.Random random = new System.Random();
        double result = random.NextDouble();
        return result;
    }

    public static string NextString(params string[] inputStrings)
    {
        int maxValue = inputStrings.GetLength(0);
        System.Random random = new System.Random();
        int intResult = random.Next(maxValue);

        return inputStrings[intResult];
    }

    public static bool CoinFlip()
    {
        bool coinFlip;
        System.Random random = new System.Random();
        int flipResult = random.Next(2);
        switch (flipResult)
        {
            default:
                coinFlip = true;
                break;
            case 1:
                coinFlip = false;
                break;
        }

        return coinFlip;
    }
}