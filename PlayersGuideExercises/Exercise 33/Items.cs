using System.Drawing;

namespace Exercise_33;

public class Sword {}
public class Axe {}
public class Bow {}

public class ColoredItem(object item, ConsoleColor color)
{
    private object _item = item;
    private ConsoleColor _color = color;
    
    public void Display()
    {
        Console.ForegroundColor = _color;
        Console.WriteLine(_item.ToString());
    }
}
