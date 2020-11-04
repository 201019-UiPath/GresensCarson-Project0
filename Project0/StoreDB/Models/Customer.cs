using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Models
{
  public class Customer : Person
  {
    private List<Order> orderHistory;
    public List<Order> OrderHistory { get; set; }
    public void addOrderToHistory(Order o)
    {
      orderHistory.Add(o);
    }

    public Customer()
    {
      Id = 0;
      Name = "Bob";
    }

    public Customer(string n, int i)
    {
      Id = i;
      Name = n;
    }
  }
}