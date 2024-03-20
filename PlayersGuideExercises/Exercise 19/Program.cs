using Exercise_19;

Game game = new();
game.GameFunction();
if (game.Blimp.Health == 0)
{
    Console.WriteLine("Congratulations! You Win!");
}
else if (game.City.Health == 0)
{
    Console.WriteLine("Sorry, you've lost.");
}
else if (game.City.Health == 0 && game.Blimp.Health == 0)
{
    Console.WriteLine("Sorry, you've lost.");
}