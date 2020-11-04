using StoreDB;
using StoreDB.Models;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StoreUI.Menus
{
  public class EmployeeMenu : IMenu
  {
    public void Start()
    {
      // first step: get info to create a customer object & check if that
      // customer is in the db

      string proceed = "";
      Employee em;
      do
      {
        em = LogIn();
        if (em.Id == -1)
        {
          Console.WriteLine("Quitting now.");
          return;
        }
        if (em.Id == -2)
        {
          Console.WriteLine("Sorry, that is not a valid login. Select an option to proceed");
          Console.WriteLine("[0] Try Again");
          Console.WriteLine("[Any other key] Quit");
          proceed = Console.ReadLine();
        }
      } while (ValidInput(proceed, "0"));

      // Next Step:

      StoreContext context = new StoreContext();
      DbRepo repo = new DbRepo(context);

      Console.WriteLine($"Welcome {em.Name}, what would you like to do?");
      Console.WriteLine("[0] Check item inventory");
      Console.WriteLine("[1] Restock an item");
      Console.WriteLine("[Any other key] Quit");

      string job = Console.ReadLine();
      if (!ValidInput(job, "0|1"))
      {
        Console.WriteLine("Goodbye, Have a nice day!");
        return;
      }

      if (ValidInput(job, "0"))
      {
        InventoryUi(repo);
      }

      if (ValidInput(job, "1"))
      {
        RestockUi(repo, new Milk());
      }

    }

    public Employee LogIn()
    {
      //ask user for employee details or quit
      Console.WriteLine("Welcome Employee! Would you like to:");
      Console.WriteLine("[0] Log in \n[1]New Employee");
      Console.WriteLine("[Any other key] Quit");
      string newEmp = Console.ReadLine();

      if (!ValidInput(newEmp, "0|1")) { return new Employee("", -1); } //exit if employee wants to quit

      Console.Clear();
      Console.Write("Please enter your Name: ");
      string empName = Console.ReadLine();
      Console.Write("Please enter your numeric Id: ");
      string empId = Console.ReadLine();

      while (ValidInput(empId, "\\D"))
      {
        Console.WriteLine("Sorry, that was not a valid Id.");
        Console.Write("Please enter a positive integer: ");
        empId = Console.ReadLine();
      }
      Employee emp = new Employee(empName, Convert.ToInt32(empId));
      StoreContext context = new StoreContext();
      DbRepo repo = new DbRepo(context);
      Employee employeeIdCheck = repo.GetEmployeeById(Convert.ToInt32(empId));
      if (employeeIdCheck != null && ValidInput(newEmp, "1"))
      {
        return new Employee("", -2);
      }
      if (employeeIdCheck != null && ValidInput(newEmp, "0"))
      {
        return employeeIdCheck;
      }

      return emp;

    }

    public void RestockUi(DbRepo repo, Product p)
    {
      // ask for product and restock
      ProductTasks pt = new ProductTasks(repo);
      EmployeeTasks et = new EmployeeTasks(repo);
      Product realProduct = new Product();
      if (pt.GetProductById(p.Id).Equals(p.Id)) { }
      else { pt.AddProduct(p); }

      string id;
      string proceed = "0";
      do
      {

        Console.WriteLine("Please enter a valid Product id");
        id = Console.ReadLine();
        while (ValidInput(id, "\\D"))
        {
          Console.WriteLine("Sorry, please enter a whole number!");
          id = Console.ReadLine();
        }

        realProduct = repo.GetProductById(Convert.ToInt32(id));

        if (realProduct == null)
        {
          Console.WriteLine("Sorry, That id number was not valid!");
          Console.WriteLine("Please select an option: \n[0] try again \n[any other key] quit");
        }
      } while (ValidInput(proceed, "0"));

      et.RestockProductGlobal(realProduct);

    }

    public void InventoryUi(DbRepo repo)
    {
      // retrieve info from database and print to console

      LocationTasks lt = new LocationTasks(repo);

      string address;
      string proceed;
      List<Product> inventory;
      List<Location> locations = lt.GetAllLocations();
      Location validAddress;
      do
      {
        Console.WriteLine("Please enter a valid location address:");
        address = Console.ReadLine();
        validAddress = lt.GetLocationByAddress(address);
        if (locations.Contains(validAddress)) { proceed = "0"; }
        else
        {
          Console.WriteLine("Sorry, please enter either a valid location address or [1] to quit");
          proceed = Console.ReadLine();
        }
      } while (!ValidInput(proceed, "0|1"));

      if (ValidInput(proceed, "1"))
      { return; }

      inventory = validAddress.Inventory;
      Console.WriteLine($"Our Location at {validAddress.Address} has the following inventory:");

      foreach (Product p in inventory)
      {
        Console.WriteLine($"{p.Name} with {p.Stock} in stock");
      }
    }

    public bool ValidInput(string input, string regex)
    {
      if (Regex.IsMatch(input, regex))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}