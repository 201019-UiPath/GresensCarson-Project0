using System;
using System.Collections.Generic;
using StoreLib.Models;
using StoreLib;

namespace StoreDB
{
  public interface ILocationRepo
  {
    void AddLocation(Location loc);
    void RemoveLocation(Location loc);
    void UpdateLocation(Location loc); //say stuff gets restocked, inventory changes, etc.
    Location GetLocationByAddress(string address);
    Location GetLocationById(int id);
    List<Product> GetInventory(Location loc);

  }
}