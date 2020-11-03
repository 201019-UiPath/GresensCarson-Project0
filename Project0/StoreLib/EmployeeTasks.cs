using StoreLib.Models;
using System.Collections.Generic;

namespace StoreLib
{
  public class EmployeeTasks
  {
    public void UpdateInventory()
    {
      //get info from order db & update location db
    }

    public List<Product> CheckInventory()
    {
      //check total inventory
      UpdateInventory();
      List<Product> lst = new List<Product>();
      return lst;
    }

    public List<Product> CheckInventory(Location loc)
    {
      //check inventory at a specific store location
      List<Product> lst = new List<Product>();
      return lst;
    }

    public void RestockProductLocation(Product p, Location loc)
    {
      //restock product at location
    }

    public void RestockProductGlobal(Product p)
    {
      //restock product everywhere
      if (p is Cheese c) { p.Stock = Cheese.MaxStock; }
      if (p is Milk m) { p.Stock = Milk.MaxStock; }
      if (p is IceCream ic) { p.Stock = IceCream.MaxStock; }
    }

    public void RestockLocation(Location loc)
    {
      //restock everything at a specific location
    }

    public void GlobalRestock()
    {
      //restock everything everywhere
    }
  }
}