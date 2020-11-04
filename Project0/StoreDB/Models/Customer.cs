using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Models
{
  public class Customer : Person
  {
    private List<Order> orderHistory;
    public List<Order> OrderHistory { get; set; }
    public void AddOrderToHistory(Order o)
    {
      orderHistory.Add(o);
    }

    public Customer()
    {
      Id = 0;
      Name = "Bob";
      orderHistory = new List<Order>();
    }

    public Customer(string n, int i)
    {
      Id = i;
      Name = n;
      orderHistory = new List<Order>();

    }
  }
}