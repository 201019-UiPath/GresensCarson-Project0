using StoreDB;
using StoreDB.Models;
using System;
using System.Text.RegularExpressions;

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
        InventoryUi();
      }

      if (ValidInput(job, "1"))
      {
        RestockUi();
      }

    }

    public Employee LogIn()
    {
      //ask user for employee details or quit
      Console.WriteLine("Welcome Employee! Would you like to:");
      Console.WriteLine("[0] Log in");
      Console.WriteLine("[Any other key] Quit");
      string newEmp = Console.ReadLine();

      if (!ValidInput(newEmp, "0")) { return new Employee("", -1); } //exit if employee wants to quit

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
      // if( ! emp in db ){
      //           return employee with id -2 with method
      // }
      // if (emp in db){
      //  return emp with associated info
      // }

      return emp;

    }

    public void RestockUi()
    {
      // ask for product and restock
    }

    public void InventoryUi()
    {
      // retrieve info from database and print to console
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