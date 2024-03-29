namespace Exercise_25;

public class Card(Suit suit, Number number)
{
    public Suit Suit { get; private set; } = suit;
    public Number Number { get; private set; } = number;
}