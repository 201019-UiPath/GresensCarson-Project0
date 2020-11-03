using System.Collections.Generic;
namespace StoreLib.Models
{
  public class Location
  {
    private int id;
    private string address;
    private List<Product> inventory;
    private List<Employee> employees;

    public int Id { get; set; }
    public string Address { get; set; }
    public List<Product> Inventory { get { return inventory; } }
    public List<Employee> Employees { get { return employees; } }

    public Location()
    {
      Id = 0;
      Address = "1 Store Ave";
      List<Product> stuff = new List<Product>();
      inventory = stuff;
      employees = new List<Employee>();
    }

    public Location(int i, string add, List<Product> stuff, List<Employee> people)
    {
      Id = i;
      Address = add;
      inventory = stuff;
      employees = people;
    }

    public void AddToInventory(Product p)
    {
      inventory.Add(p);
    }
    public void AddEmployee(Employee e)
    {
      inventory.Add(e);
    }

    public void RemoveFromInventory(Product p)
    {
      inventory.Remove(p);
    }
    public void RemoveEmployee(Employee e)
    {
      inventory.Remove(e);
    }


  }
}