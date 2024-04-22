namespace exercise_29;

public class Pack(double maxWeightHeld, double maxVolumeHeld, int maxItemsHeld = 1)
{
    private int _maxItemsHeld = maxItemsHeld;
    private double _maxWeightHeld = maxWeightHeld;
    private double _maxVolumeHeld = maxVolumeHeld;

    public InventoryItem[] packArray = new InventoryItem[maxItemsHeld];
}