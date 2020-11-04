using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB
{
  public class LocationTasks
  {
    private ILocationRepo repo;

    public LocationTasks(ILocationRepo repo)
    {
      this.repo = repo;
    }

    public void AddLocation(Location loc)
    {
      repo.AddLocation(loc);
    }

    public void UpdateLocation(Location loc)
    {
      repo.UpdateLocation(loc);
    }

    public Location GetLocationById(int id)
    {
      return repo.GetLocationById(id);
    }

    public Location GetLocationByAddress(string address)
    {
      return repo.GetLocationByAddress(address);
    }

    public List<Location> GetAllLocations()
    {
      return repo.GetAllLocations();
    }

    public List<Product> GetInventory(Location loc)
    {
      return repo.GetInventory(loc);
    }

    public void RemoveLocation(Location location)
    {
      repo.RemoveLocation(location);
    }

  }
}