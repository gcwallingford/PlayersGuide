Console.WriteLine("Target Row:");
int targetRow = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Target Column:");
int targetColumn = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Deploy to:");
Console.WriteLine("(" + --targetRow + ", " + targetColumn + ")");
Console.WriteLine("(" + targetRow + ", " + --targetColumn + ")");
Console.WriteLine("(" + ++targetRow + ", " + targetColumn + ")");
Console.WriteLine("(" + targetRow + ", " + ++targetColumn + ")");
