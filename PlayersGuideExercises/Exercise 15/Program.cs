Console.WriteLine("User 1 enter value:");
int input1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("User 2 enter value:");
int input2 = Convert.ToInt32(Console.ReadLine());
input2 /= input1;
Console.WriteLine(input2);
do
{
    if (input2 == input1)
    {
        Console.WriteLine("Entered value is correct. Good Job!");
        break;
    }

    if (input2 < input1)
    {
        Console.WriteLine("Entered value is too low, try again");
        input2 = Convert.ToInt32(Console.ReadLine());
    }

    if (input2 > input1)
    {
        Console.WriteLine("Entered value is too high, try again.");
        input2 = Convert.ToInt32(Console.ReadLine());
    }
} while (input2 != input1);
