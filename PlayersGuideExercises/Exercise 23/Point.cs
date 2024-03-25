namespace Exercise_23;

public class Point
{
    public int X { get; private set;}
    public int Y { get; private set;}

    public Point(int x = 0, int y = 0)
    {
        this.X = x;
        this.Y = y;
    }
}