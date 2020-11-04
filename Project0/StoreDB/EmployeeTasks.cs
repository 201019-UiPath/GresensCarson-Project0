using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB
{
  public class EmployeeTasks
  {
    private DbRepo repo;
    public EmployeeTasks(DbRepo r)
    {
      repo = r;
    }
    public EmployeeTasks() { }

    public void RestockProductGlobal(Product p)
    {
      //restock product everywhere
      if (p is Cheese c) { p.Stock = Cheese.MaxStock; }
      if (p is Milk m) { p.Stock = Milk.MaxStock; }
      if (p is IceCream ic) { p.Stock = IceCream.MaxStock; }
      repo.UpdateProducts(p);
    }

  }
}