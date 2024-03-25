namespace Exercise_22;

public class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private int _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, int length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    public static Arrow BuildArrow(string arrowheadInput, string fletchingInput, int shaftInput)
    {
        Arrowhead arrowhead = Arrowhead.Empty;
        Fletching fletching = Fletching.Empty;
        
        Arrow finalArrow = new Arrow(arrowhead, fletching, shaftInput);
        
        if (arrowheadInput == "1")
        {
            finalArrow._arrowhead = Arrowhead.Steel;
        }
        else if (arrowheadInput == "2")
        {
            finalArrow._arrowhead = Arrowhead.Wood;
        }
        else if (arrowheadInput == "3")
        {
            finalArrow._arrowhead = Arrowhead.Obsidian;
        }

        if (fletchingInput == "1")
        {
            finalArrow._fletching = Fletching.Plastic;
        }
        else if (fletchingInput == "2")
        {
            finalArrow._fletching = Fletching.Goose;
        }
        else if (fletchingInput == "3")
        {
            finalArrow._fletching = Fletching.Turkey;
        }

        return finalArrow;
    }

    public float ArrowPrice()
    {
        float price = 0;
        if (_arrowhead == Arrowhead.Steel)
        {
            price += 10;
        }
        else if (_arrowhead == Arrowhead.Wood)
        {
            price += 3;
        }
        else if (_arrowhead == Arrowhead.Obsidian)
        {
            price += 5;
        }

        if (_fletching == Fletching.Plastic)
        {
            price += 10;
        }
        else if (_fletching == Fletching.Goose)
        {
            price += 3;
        }
        else if (_fletching == Fletching.Turkey)
        {
            price += 5;
        }

        float lengthCost = _length * 0.05f;
        price += lengthCost;
        return price;
    }
}