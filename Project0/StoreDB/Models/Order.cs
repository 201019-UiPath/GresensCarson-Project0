using System.Collections.Generic;

namespace StoreDB.Models
{
  public class Order
  {
    private List<Product> items;
    private int id;
    private double price;
    private string date;

    public int Id { get; set; }
    public double Price { get; set; }
    public string Date { get; set; }
    public List<Product> Items { get; set; }

    public Order(List<Product> pList)
    {
      items = pList;
      //check db for number of orders and create an id from that
    }

    public Order(List<Product> pList, int i)
    {
      items = pList;
      Id = i;
    }

    public Order()
    {

    }


    public void AddProduct(Product p)
    {
      items.Add(p);
    }

    public void RemoveProduct(Product p)
    {
      items.Remove(p);
    }

    public void CancelOrder()
    {

      foreach (Product p in items)
      {
        p.Stock = p.Stock + 1;
      }

      List<Product> emptyProductList = new List<Product>();
      items = emptyProductList;

      Id = -1;
      price = 0.0;
    }

    public void UpdatePrice()
    {
      price = OrderPrice();
    }

    public double OrderPrice()
    {
      //sum up all product prices in order list
      double priceCounter = 0.0;
      foreach (Product p in items)
      {
        priceCounter += p.Price;
      }
      return priceCounter;
    }

  }
}