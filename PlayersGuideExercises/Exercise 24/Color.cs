namespace Exercise_24;

public class Color
{
    public int R { get; set; }
    public int G { get; set; }
    public int B { get; set; }

    public static Color Green => new Color(0, 255);
    
    public Color(int r = 0, int g = 0, int b = 0)
    {
        this.R = r;
        this.G = g;
        this.B = b;
    }
}