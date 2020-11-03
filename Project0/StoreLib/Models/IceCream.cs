namespace StoreLib.Models
{
  public class IceCream : Product
  {
    private static int maxStock = 150;
    public static int MaxStock { get { return maxStock; } }
    public IceCream()
    {
      Stock = 150;
      Name = "Carton of Ice Cream";
      Id = 3;
      Price = 11.99;
    }
  }
}