namespace Exercise_19;

public class Entity(int health)
{
   private int _health = health;
   public int Health
   {
      get => _health;
      set => _health = value;
   }
}