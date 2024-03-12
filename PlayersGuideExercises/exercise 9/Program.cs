Console.WriteLine("How many eggs were gathered:");
int eggNumber = Convert.ToInt32(Console.ReadLine());
int toEach = eggNumber/4;
int toBear = eggNumber%4;
Console.WriteLine("To each sister: " + toEach);
Console.WriteLine("To the Bear: " + toBear);