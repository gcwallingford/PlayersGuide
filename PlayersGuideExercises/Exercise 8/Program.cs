using System.Security.Claims;

Console.WriteLine("Enter the triangles base:");
int tBase = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the triangles height:"); 
int tHeight = Convert.ToInt32(Console.ReadLine());
double area = tBase * tHeight / 2;
Console.WriteLine("The triangles area is " + area);