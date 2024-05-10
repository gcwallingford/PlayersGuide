using Random = Exercise_37.Random;

double nextDouble = Random.NextDouble(10);
string nextString = Random.NextString("string 1", "string 2", "sting", "Sting of Police fame");
bool coinFlip = Random.CoinFlip();

Console.WriteLine(nextDouble);
Console.WriteLine(nextString);
Console.WriteLine(coinFlip);
