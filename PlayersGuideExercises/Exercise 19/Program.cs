using Exercise_19;

Game game = new();
game.GameFunction();
if (game.blimp.health == 0)
{
    Console.WriteLine("Congratulations! You Win!");
}

if (game.city.health == 0)
{
    Console.WriteLine("Sorry, you've lost.");
}