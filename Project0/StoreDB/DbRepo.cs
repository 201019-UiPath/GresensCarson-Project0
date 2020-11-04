using System.Collections.Generic;
using StoreDB.Models;
using System.Linq;
using System;

namespace StoreDB
{
  public class DbRepo : ICustomerRepo, IEmployeeRepo, ILocationRepo, IOrderRepo, IProductRepo
  {
    private StoreContext context;
    public DbRepo(StoreContext sc)
    {
      context = sc;
    }
    public void AddCustomer(Customer c)
    {
      context.Customers.Add(c);
      context.SaveChanges();
    }

    public void AddEmployee(Employee e)
    {
      context.Employees.Add(e);
      context.SaveChanges();
    }

    public void AddLocation(Location loc)
    {
      context.Locations.Add(loc);
      context.SaveChanges();
    }

    public void AddOrder(Order o)
    {
      context.Orders.Add(o);
      context.SaveChanges();
    }

    public void AddProduct(Product p)
    {
      context.Products.Add(p);
      context.SaveChanges();
    }

    public List<Customer> GetAllCustomers()
    {
      return context.Customers.ToList();
    }

    public List<Employee> GetAllEmployees()
    {
      return context.Employees.ToList();
    }

    public List<Location> GetAllLocations()
    {
      return context.Locations.ToList();
    }

    public List<Order> GetAllOrders()
    {
      return context.Orders.ToList();
    }

    public List<Product> GetAllProducts()
    {
      return context.Products.ToList();
    }

    public Customer GetCustomerById(int id)
    {
      return context.Customers.Single(c => c.Id == id);
    }

    public Employee GetEmployeeById(int id)
    {
      return context.Employees.Single(e => e.Id == id);
    }

    public Employee GetEmployeeByLocation(Location loca)
    {
      return context.Employees.Single(e => e.Loc == loca);
    }

    public Employee GetEmployeeBySalary(int sal)
    {
      return context.Employees.Single(e => e.Salary == sal);
    }

    public List<Product> GetInventory(Location loc)
    {
      return context.Locations.Single(l => l == loc).Inventory;
    }

    public Location GetLocationByAddress(string address)
    {
      return context.Locations.Single(l => l.Address == address);
    }

    public Location GetLocationById(int id)
    {
      return context.Locations.Single(l => l.Id == id);
    }

    public List<Order> GetOrderByDate(bool asc)
    {
      if (asc)
      {
        return context.Orders.OrderBy(o => o.Date).ToList();
      }
      else
      {
        return context.Orders.OrderByDescending(o => o.Date).ToList();
      }
    }

    public Order GetOrderById(int id)
    {
      return context.Orders.Single(o => o.Id == id);
    }

    public Order GetOrderByPrice(double price)
    {
      return context.Orders.Single(o => o.Price == price);
    }

    public Product GetProductById(int id)
    {
      return context.Products.Single(p => p.Id == id);
    }

    public Product GetProductByName(string name)
    {
      return context.Products.Single(p => p.Name == name);
    }
    public void RemoveCustomer(Customer c)
    {
      context.Customers.Remove(c);
      context.SaveChanges();
    }

    public void RemoveEmployee(Employee e)
    {
      context.Employees.Remove(e);
      context.SaveChanges();
    }

    public void RemoveLocation(Location loc)
    {
      context.Locations.Remove(loc);
      context.SaveChanges();
    }

    public void RemoveOrder(Order o)
    {
      context.Orders.Remove(o);
      context.SaveChanges();
    }

    public void RemoveProduct(Product p)
    {
      context.Products.Remove(p);
      context.SaveChanges();
    }

    public void UpdateCustomer(Customer c)
    {
      context.Customers.Update(c);
      context.SaveChanges();
    }

    public void UpdateEmployee(Employee e)
    {
      context.Employees.Update(e);
      context.SaveChanges();
    }

    public void UpdateLocation(Location loc)
    {
      context.Locations.Update(loc);
      context.SaveChanges();
    }

    public void UpdateOrder(Order o)
    {
      context.Orders.Update(o);
      context.SaveChanges();
    }

    public void UpdateProducts(Product p)
    {
      context.Products.Update(p);
      context.SaveChanges();
    }
  }
}