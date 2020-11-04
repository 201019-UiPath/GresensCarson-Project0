using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB
{
  public class ProductTasks
  {
    private IProductRepo repo;
    public ProductTasks(IProductRepo r)
    {
      repo = r;
    }

    public void AddProduct(Product p)
    {
      repo.AddProduct(p);
    }
    public void UpdateProducts(Product p)
    {
      repo.UpdateProducts(p);
    }
    public Product GetProductById(int id)
    {
      return repo.GetProductById(id);
    }
    public Product GetProductByName(string name)
    {
      return repo.GetProductByName(name);
    }
    public List<Product> GetAllProducts()
    {
      return repo.GetAllProducts();
    }
    public void RemoveProduct(Product p)
    {
      repo.RemoveProduct(p);
    }
  }
}