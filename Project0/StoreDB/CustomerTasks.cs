using StoreDB.Models;
using System.Collections.Generic;
using StoreDB;

namespace StoreDB
{
  public class CustomerTasks
  {
    private ICustomerRepo repo;
    public CustomerTasks() { }
    public CustomerTasks(ICustomerRepo r)
    {
      repo = r;
    }

    public List<Order> GetOrderHistory(Customer c)
    {
      //get the customer's order history
      List<Order> lst = new List<Order>();
      return lst;
    }

    public List<Order> GetOrderHistoryByPrice(Customer c, bool asc)
    {
      // call GetOrderHistory then sort by cost
      List<Order> lst = new List<Order>();
      return lst;
    }

    public List<Order> GetOrderHistoryByAge(Customer c, bool asc)
    {
      // call GetOrderHistory then sort by age
      List<Order> lst = new List<Order>();
      return lst;
    }

    public List<Product> GetLocationInventory(Location loc)
    {
      //get inventory of a location
      //maybe void?
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