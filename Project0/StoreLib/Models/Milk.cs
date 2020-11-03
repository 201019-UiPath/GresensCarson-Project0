namespace StoreLib.Models
{
  public class Milk : Product
  {
    private static int maxStock = 50;
    public static int MaxStock { get { return maxStock; } }
    public Milk()
    {
      Stock = 50;
      Name = "Gallon Jug of Milk";
      Id = 2;
      Price = 4.99;
    }
  }
}