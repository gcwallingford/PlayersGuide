int[] array =  new int[5];
Console.WriteLine("Enter 5 values, write each then press enter");
array[0] = Convert.ToInt32(Console.ReadLine());
array[1] = Convert.ToInt32(Console.ReadLine());
array[2] = Convert.ToInt32(Console.ReadLine());
array[3] = Convert.ToInt32(Console.ReadLine());
array[4] = Convert.ToInt32(Console.ReadLine());
int[] array2 = new int[5];
for (int i = 0; i < 5; i++)
{
    array2[i] = array[i];
}
Console.WriteLine("Array 1:");
foreach (var index in array)
{
    Console.WriteLine(index);
}
Console.WriteLine(" ");
Console.WriteLine("Array 2:");
foreach (var index in array2)
{
    Console.WriteLine(index);
}