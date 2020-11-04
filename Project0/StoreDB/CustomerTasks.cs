using StoreDB.Models;
using System.Collections.Generic;
using StoreDB;

namespace StoreDB
{
  public class CustomerTasks
  {
    private DbRepo repo;
    public CustomerTasks() { }
    public CustomerTasks(DbRepo r)
    {
      repo = r;
    }

    public List<Order> GetOrderHistory(Customer c)
    {
      // call GetOrderHistory then sort by cost
      return repo.GetOrdersByCustomerId(c);
    }

    public List<Order> GetOrderHistoryByDate(Customer c, bool asc)
    {
      // call GetOrderHistory then sort by age
      return repo.GetOrdersByDateCustomer(c, asc);
    }

    public List<Product> GetLocationInventory(Location loc)
    {
      //get inventory of a location
      List<Product> lst = new List<Product>();
      return lst;
    }

    public int CheckStock(Product p)
    {
      //check the remaining stock of product p
      return p.Stock;

    }

    public int CheckLocationStock(Product p, Location loc)
    {
      //check the remaining stock of product p at location loc
      List<Product> lst = loc.Inventory;
      int i = lst.IndexOf(p);
      if (i.Equals(-1)) { throw new OutOfStockException(); }
      else
      {
        int stock = p.Stock;
        return stock;
      }
    }

  }
}