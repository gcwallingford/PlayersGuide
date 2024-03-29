using Exercise_25;

foreach (Suit suits in Enum.GetValues(typeof(Suit)))
{
    foreach(Number numbers in Enum.GetValues(typeof(Number))) 
    {
        Card card = new Card(suits, numbers);
        Console.WriteLine("The " + card.Number + " of " + card.Suit );
    }
}