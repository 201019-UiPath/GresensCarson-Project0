using System;
using System.Collections.Generic;
using StoreLib.Models;
using StoreLib;

namespace StoreDB
{
  public interface IOrderRepo
  {
    void AddOrder(Order o);
    void UpdateOrder(Order o);
    // void CancelOrder(Order o); //No cancel order since UI asks for certainty before adding it to db 
    Order GetOrderById(int id);
    Order GetOrderByPrice(double price);
    List<Order> GetOrderByDate(bool asc);
    List<Order> GetAllOrders();
  }
}