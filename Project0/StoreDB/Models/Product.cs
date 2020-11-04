namespace StoreDB.Models
{
  public class Product
  {
    private double price;
    private int id;
    private string name;
    private int stock;
    private static int maxStock;
    public int MaxStock { get { return maxStock; } }
    protected void SetMaxStock(int i) { maxStock = i; }

    public double Price { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
  }
}