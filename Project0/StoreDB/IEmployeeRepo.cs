using System;
using System.Collections.Generic;
using StoreLib.Models;
using StoreLib;

namespace StoreDB
{
  public interface IEmployeeRepo
  {
    void AddEmployee(Employee e);
    void RemoveEmployee(Employee e);
    void UpdateEmployee(Employee e); //update salary,name, location, etc.
    Employee GetEmployee(string name, int id);
    Employee GetEmployee(int id, string name);
    Employee GetEmployeeBySalary(int sal);
    Employee GetEmployeeByLocation(Location loc);
    List<Employee> GetAllEmployees();

  }
}