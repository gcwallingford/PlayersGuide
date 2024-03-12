Console.WriteLine("Enter the number of Estates:");
int estatePoints = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the number of Duchies:");
int duchyPoints = 3 * Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the number of Provinces:");
int provincePoints = 6 * Convert.ToInt32(Console.ReadLine());
int total = estatePoints + duchyPoints + provincePoints;
Console.WriteLine("Total number of points is " + total);