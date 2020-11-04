using System;
using System.Collections.Generic;
using StoreDB.Models;
using StoreLib;

namespace StoreDB
{
  public interface ICustomerRepo
  {
    void AddCustomer(Customer c);
    void RemoveCustomer(Customer c);
    void UpdateCustomer(Customer c); //ie. update their order history
    Customer GetCustomerById(int id);
    List<Customer> GetAllCustomers();
    List<Order> GetOrdersByDateCustomer(Customer cus, bool asc);

  }
}