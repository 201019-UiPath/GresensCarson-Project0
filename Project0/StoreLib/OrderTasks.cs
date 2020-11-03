using StoreLib.Models;
using System.Collections.Generic;

namespace StoreLib
{
  public class OrderTasks
  {
    public void AddProduct(Order o, Product p)
    {
      //add product to items list
      o.AddProduct(p);
      o.UpdatePrice();
      p.Stock = p.Stock - 1;
      if (p.Stock < 0)
      {
        p.Stock = p.Stock + 1;
        throw new OutOfStockException($"Sorry! We're out of {p.Name}");
      }
    }

    public void RemoveProduct(Order o, Product p)
    {
      //remove product from items list
      o.RemoveProduct(p);
      o.UpdatePrice();
      if (p.Stock < p.MaxStock) { p.Stock = p.Stock + 1; }

    }

    public void CancelOrder(Order o)
    {
      //remove all products from product list & set id/price to defaults
      o.CancelOrder();
    }

    public void RecordOrderLoc(Order o, Location loc)
    {
      //record order made at this location
    }

    public void RecordOrderGlobal(Order o)
    {
      //record order
    }

    public double OrderPrice(Order o)
    {
      //sum up all product prices in order list
      return o.OrderPrice();

    }
  }
}