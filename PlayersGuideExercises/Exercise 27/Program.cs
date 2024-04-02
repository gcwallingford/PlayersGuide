using Exercise_27;

Validator validator = new Validator();

Console.WriteLine("Please enter a password:");

if (validator.FullValidator(Console.ReadLine()) == true)
{
    Console.WriteLine("Password is valid");
}
