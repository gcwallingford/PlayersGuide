Console.WriteLine("Enter X value:");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter Y value:");
int y = Convert.ToInt32(Console.ReadLine());
string output;

if (x < 0)
{
    output = "W";
}
else if (x > 0)
{
    output = "E";
}
else
{
    output = "";
}

if (y < 0)
{
    output = "S" + output;
}
else if (y > 0)
{
    output = "N" + output;
}
else
{
    output = "" + output;
}

Console.WriteLine("Enemy Position:" + output);