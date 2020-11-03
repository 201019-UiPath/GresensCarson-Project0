using System;
using System.Text.RegularExpressions;


namespace StoreUI.Menus
{
    public class MainMenu:IMenu
    {
     public void Start(){
              
      Console.WriteLine("Hello Welcome to the Dairy Shop! Are you a \n [0] Customer \n [1] Employee?");
      string user = Console.ReadLine();

// check input if customer, employee, or other
      do{
        if (user == "1") { 
          Console.Clear();
          EmployeeMenu eMenu = new EmployeeMenu();
          eMenu.Start();
          return;
        }
    
        if (user == "0") {  
          Console.Clear();
          CustomerMenu cMenu = new CustomerMenu();
          cMenu.Start();
          return;   
          }

        Console.WriteLine();
        Console.WriteLine("Press any key to quit.");
        user = Console.ReadLine();
      }while((Regex.IsMatch(user,"0|1")));

     }
    }
}