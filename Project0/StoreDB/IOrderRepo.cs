using System;
using System.Collections.Generic;
using StoreDB.Models;
using StoreLib;

namespace StoreDB
{
  public interface IOrderRepo
  {
    void AddOrder(Order o);
    void UpdateOrder(Order o);
    void RemoveOrder(Order o);
    Order GetOrderById(int id);
    Order GetOrderByPrice(double price);
    List<Order> GetOrderByDate(bool asc);
    List<Order> GetAllOrders();
  }
}