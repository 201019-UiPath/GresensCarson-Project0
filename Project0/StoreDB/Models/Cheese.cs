namespace StoreDB.Models
{
  public class Cheese : Product
  {
    private static int maxStock = 100;
    public static int MaxStock { get { return maxStock; } }
    public Cheese()
    {
      Stock = 100;
      Name = "Wheel of Cheese";
      Id = 1;
      Price = 24.99;
    }
  }
}