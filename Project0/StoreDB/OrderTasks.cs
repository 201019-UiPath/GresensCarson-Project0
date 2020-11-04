using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB
{
  public class OrderTasks
  {
    private IOrderRepo repo;

    public OrderTasks(IOrderRepo r)
    {
      repo = r;
    }

    public OrderTasks() { }

    public void AddOrder(Order o)
    {
      //allows the customer to make an order -> send it to db
      repo.AddOrder(o);
    }

    public void UpdateOrder(Order o)
    {
      repo.UpdateOrder(o);
    }

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
      repo.RemoveOrder(o);
    }

    public Order GetOrderById(int id)
    {
      return repo.GetOrderById(id);
    }

    public Order GetOrderByPrice(double p)
    {
      return repo.GetOrderByPrice(p);
    }


    public List<Order> GetOrderByDate(bool asc)
    {
      return repo.GetOrderByDate(asc);
    }


    public double OrderPrice(Order o)
    {
      //sum up all product prices in order list
      return o.OrderPrice();
    }
  }
}