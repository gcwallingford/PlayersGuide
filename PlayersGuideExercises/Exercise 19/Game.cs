namespace Exercise_19;

public class Game
{
    public Entity City = new(15);
    public Entity Blimp = new(10);
    public void GameFunction()
    {
        Console.WriteLine("User 1 enter value:");
        int input1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("User 2 enter value:");
        int input2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(input2);
        
        
        do
        {
            if (input2 == input1)
            {
                Console.WriteLine("Entered value is correct. Good Job!");
                Blimp.Health--;
                City.Health--;
                input2 = Convert.ToInt32(Console.ReadLine());
                break;
            }

            if (input2 < input1)
            {
                Console.WriteLine("Entered value is too low, try again");
                City.Health--;
                input2 = Convert.ToInt32(Console.ReadLine());
            }

            if (input2 > input1)
            {
                Console.WriteLine("Entered value is too high, try again.");
                City.Health--;
                input2 = Convert.ToInt32(Console.ReadLine());
            }
        } while (City.Health != 0 || Blimp.Health != 0);
    }
}