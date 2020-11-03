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
    Employee GetEmployeeById(int id);
    Employee GetEmployeeBySalary(int sal);
    Employee GetEmployeeByLocation(Location loc);
    List<Employee> GetAllEmployees();

  }
}