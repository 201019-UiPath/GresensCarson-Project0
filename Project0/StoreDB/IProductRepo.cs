using System;
using System.Collections.Generic;
using StoreLib.Models;
using StoreLib;

namespace StoreDB
{
  public interface IProductRepo
  {
    void AddProduct(Product p); //add product to db
    void UpdateProducts(Product p); // update products table when something happens
    Product GetProductById(int id);
    Product GetProductByName(string name);
    List<Product> GetAllProducts();
    void RemoveProduct(Product p); //remove product from db
  }
}