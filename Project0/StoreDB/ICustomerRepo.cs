using System;
using System.Collections.Generic;
using StoreLib.Models;
using StoreLib;

namespace StoreDB
{
  public interface ICustomerRepo
  {
    void AddCustomer(Customer c);
    void RemoveCustomer(Customer c);
    void UpdateCustomer(Customer c); //ie. update their order history
    Customer GetCustomer(string name, int id);
    Customer GetCustomer(int id, string name);
    List<Customer> GetAllCustomers();

  }
}