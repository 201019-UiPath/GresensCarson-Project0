namespace StoreLib.Models
{
  public class Employee : Person
  {
    private Location loc;
    private int salary;

    public Location Loc { get; set; }
    public int Salary { get; set; }

    public Employee()
    {
      Id = 1;
      Name = "Jim";
      Location = new Location();
      Salary = 30000;
    }

    public Employee(string n, int i, Location l, int sal)
    {
      Id = i;
      Name = n;
      Loc = l;
      Salary = sal;
    }
  }
}