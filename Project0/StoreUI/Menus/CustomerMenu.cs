using System;
using StoreDB;
using System.Text.RegularExpressions;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreUI.Menus
{
  public class CustomerMenu : IMenu
  {
    public void Start()
    {
      // first step: get info to create a customer object & check if that
      // customer is in the db

      string proceed = "";
      Customer c;
      do
      {
        c = LogIn();
        proceed = "4";
        if (c.Id == -1)
        {
          Console.WriteLine("Quitting now.");
          return;
        }
        if (c.Id == -2)
        {
          Console.WriteLine("Sorry, that account is already claimed. Select an option to proceed");
          Console.WriteLine("[0] Try Again");
          Console.WriteLine("[1] Quit");
          proceed = Console.ReadLine();
        }
      } while (ValidInput(proceed, "0"));

      if (ValidInput(proceed, "1"))
      {
        Console.WriteLine("Quitting now.");
        return;
      }

      // Next Step: let customer make order and persist to db

      Console.WriteLine($"Hello {c.Name}! Here are Today's Products: ");
      Console.Write("Milk \nCheese \nIce Cream\n");

      Console.WriteLine("Would you like to place an order? \n[0] Yes \n[1] No");
      proceed = Console.ReadLine();
      while (!ValidInput(proceed, "0|1"))
      {
        Console.WriteLine("Sorry, please enter 0 to proceed or 1 to quit");
        proceed = Console.ReadLine();
      }

      StoreContext context = new StoreContext();
      DbRepo repo = new DbRepo(context);
      OrderTasks ot = new OrderTasks(repo);
      CustomerTasks ct = new CustomerTasks(repo);
      EmployeeTasks et = new EmployeeTasks(repo);
      LocationTasks lt = new LocationTasks(repo);
      ProductTasks pt = new ProductTasks(repo);
      List<Order> previousOH = new List<Order>();
      if (c.Equals(repo.GetCustomerById(c.Id)))
      {
        previousOH = repo.GetCustomerById(c.Id).OrderHistory;
        repo.AddCustomer(c);
      }
      else
      {
        previousOH = repo.GetCustomerById(c.Id).OrderHistory;
        repo.RemoveCustomer((repo.GetCustomerById(c.Id)));
        repo.AddCustomer(c);
      }

      previousOH = c.OrderHistory;

      if (ValidInput(proceed, "0"))
      {

        Console.WriteLine("Time to place an order!");
        Order newOrder = MakeOrder();
        newOrder.Id = c.Id;
        Order emptyOrder = new Order();

        if (newOrder.Equals(emptyOrder))
        {
          Console.WriteLine("GoodBye");
          return;
        }

        string confirm;
        double price = newOrder.OrderPrice();
        Console.WriteLine($"That will be ${price}");
        do
        {
          Console.WriteLine("Please Select [0] to pay now or [1] to cancel your order");
          confirm = Console.ReadLine();
        }
        while (!ValidInput(confirm, "0|1"));
        if (ValidInput(confirm, "0"))
        {
          c.AddOrderToHistory(newOrder);
          repo.UpdateCustomer(c);
          Console.WriteLine("Your order has been processed!");
        }
        if (ValidInput(confirm, "1"))
        {
          Console.WriteLine("Your order has been cancelled. GoodBye.");
        }
      }
      Console.Clear();
      //next step: 
      Console.WriteLine("What would you like to do now?");
      Console.WriteLine("[0] Check Order History \n[1]Check location inventory \n[3]Check product stock");
      Console.WriteLine("[4] Quit");
      string next = Console.ReadLine();
      while (!ValidInput(next, "0|1|2|3"))
      {
        Console.WriteLine("Please select a valid option to continue");
        Console.WriteLine("[0] Check Order History \n[1]Check location inventory");
        Console.WriteLine("[2] Quit");
      }

      if (ValidInput(next, "0"))
      {
        ShowOrderHistory(c, repo, previousOH);
      }
      if (ValidInput(next, "1"))
      {
        CheckInventory(repo);
      }
      if (ValidInput(next, "2"))
      {
        Console.WriteLine("Have a nice day! Goodbye!");
        return;
      }

    }

    public void ShowOrderHistory(Customer c, DbRepo repo, List<Order> prev)
    {
      CustomerTasks ct = new CustomerTasks(repo);

      string sortBy;
      List<Order> orderHistory = prev;
      do
      {
        Console.WriteLine("Would you your order history sorted by [0] oldest or [1] newest?");
        sortBy = Console.ReadLine();
      } while (!ValidInput(sortBy, "0|1"));

      if (orderHistory.Equals(null)) { orderHistory = prev; }

      if (!ValidInput(sortBy, "0")) { orderHistory.Reverse(); }


      Console.WriteLine(orderHistory);
      int i = 0;
      foreach (var ord in orderHistory)
      {
        i++;
        Console.WriteLine("Goes into loop");
        Console.WriteLine($"Order {i} cost ${ord.OrderPrice()} and contained the following:");
        foreach (Product p in ord.Items)
        {
          Console.WriteLine($"     {p.Name}");
        }
      }

    }

    public void CheckInventory(DbRepo repo)
    {
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


    public Order MakeOrder()
    {
      string doubleCheck;
      int numMilk;
      int numCheese;
      int numIceCream;
      List<Product> orderItems = new List<Product>();
      OrderTasks ot = new OrderTasks();
      do
      {
        numMilk = askForProduct("milk", "gallons");
        numCheese = askForProduct("cheese", "wheels");
        numIceCream = askForProduct("ice cream", "cartons");
        Console.WriteLine("Are you sure? \n[0] Yes, Place my order! \n[1] No, I made a mistake. Let me order again");
        Console.WriteLine("[3] No, I don't want to make an order anymore");
        doubleCheck = Console.ReadLine();
      } while (ValidInput(doubleCheck, "1"));

      for (int i = 0; i < numMilk; i++)
      {
        orderItems.Add(new Milk());
      }
      for (int i = 0; i < numCheese; i++)
      {
        orderItems.Add(new Cheese());

      }
      for (int i = 0; i < numIceCream; i++)
      {
        orderItems.Add(new IceCream());
      }
      if (ValidInput(doubleCheck, "0")) { return new Order(orderItems); }
      else { return new Order(); }

    }

    public int askForProduct(string name, string container)
    {
      int num;
      Console.Write($"How many {container} of {name} would you like: ");
      string numProd = Console.ReadLine();
      while (ValidInput(numProd, "\\D"))
      {
        Console.WriteLine("Sorry, please enter a whole number!");
        numProd = Console.ReadLine();
      }
      num = Convert.ToInt32(numProd);
      return num;

    }

    public Customer LogIn()
    {
      //ask user for customer details or quit
      Console.WriteLine("Welcome Customer! To proceed you must either:");
      Console.WriteLine("[0] Log in");
      Console.WriteLine("[1] Create an Account");
      Console.WriteLine("Press any other key to quit");
      string newCus = Console.ReadLine();

      if (!ValidInput(newCus, "0|1")) { return new Customer("", -1); } //exit if customer wants to quit

      Console.Clear();
      Console.Write("Please enter your Name: ");
      string cusName = Console.ReadLine();
      Console.Write("Please enter your numeric Id: ");
      string cusId = Console.ReadLine();

      while (ValidInput(cusId, "\\D"))
      {
        Console.WriteLine("Sorry, that was not a valid Id.");
        Console.Write("Please enter a positive integer: ");
        cusId = Console.ReadLine();
      }
      Customer cus = new Customer(cusName, Convert.ToInt32(cusId));

      StoreContext context = new StoreContext();
      DbRepo repo = new DbRepo(context);
      Customer customerIdCheck = repo.GetCustomerById(Convert.ToInt32(cusId));
      if (customerIdCheck != null && ValidInput(newCus, "1"))
      {
        return new Customer("", -2);
      }
      if (customerIdCheck != null && ValidInput(newCus, "0"))
      {
        return customerIdCheck;
      }

      return cus;

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