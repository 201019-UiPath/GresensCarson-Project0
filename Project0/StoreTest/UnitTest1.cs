using System;
using Xunit;
using StoreLib;
using StoreLib.Models;
using System.Collections.Generic;

namespace StoreTest
{
  public class UnitTest1
  {
    Product testCheese = new Cheese();
    Product testMilk = new Milk();
    Product testIceCream = new IceCream();


    [Fact]
    public void TestFindOrderPrice()
    {
      List<Product> testItems = new List<Product>();
      testItems.Add(testCheese);
      testItems.Add(testMilk);
      testItems.Add(testIceCream);

      Order testOrder = new Order(testItems);
      OrderTasks ot = new OrderTasks();

      double expectedPrice = testCheese.Price + testMilk.Price + testIceCream.Price;
      double orderPrice = ot.OrderPrice(testOrder);

      Assert.Equal(expectedPrice, orderPrice);

    }


    [Fact]
    public void TestUpdateOrderPrice()
    {
      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      OrderTasks ot = new OrderTasks();

      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testMilk);
      ot.AddProduct(emptyOrder, testIceCream);

      double priceBeforeUpdate = ot.OrderPrice(emptyOrder);
      ot.AddProduct(emptyOrder, testIceCream);
      emptyOrder.UpdatePrice();
      double priceAfterUpdate = (ot.OrderPrice(emptyOrder));
      double expectedPrice = priceBeforeUpdate + testIceCream.Price;

      Assert.Equal(expectedPrice, priceAfterUpdate);

    }

    [Fact]
    public void TestAddProducttoItemList()
    {
      List<Product> testItems = new List<Product>();
      testItems.Add(testCheese);
      testItems.Add(testMilk);
      testItems.Add(testIceCream);

      Order testOrder = new Order(testItems);
      OrderTasks ot = new OrderTasks();

      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testMilk);
      ot.AddProduct(emptyOrder, testIceCream);

      Assert.Equal(emptyOrder.Items, testOrder.Items);
    }

    [Fact]
    public void TestRemoveProducttoItemList()
    {
      List<Product> testItems = new List<Product>();
      testItems.Add(testCheese);
      testItems.Add(testMilk);
      testItems.Add(testIceCream);

      Order testOrder = new Order(testItems);
      OrderTasks ot = new OrderTasks();
      ot.RemoveProduct(testOrder, testMilk);

      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testIceCream);


      Assert.Equal(emptyOrder.Items, testOrder.Items);
    }

    [Fact]
    public void TestCancelOrder()
    {
      List<Product> testItems = new List<Product>();
      testItems.Add(testCheese);
      testItems.Add(testMilk);
      testItems.Add(testIceCream);

      List<Product> emptyProductList = new List<Product>();


      Order testOrder = new Order(testItems);
      OrderTasks ot = new OrderTasks();
      ot.CancelOrder(testOrder);

      Order nullOrder = new Order(emptyProductList);
      nullOrder.Price = 0;
      nullOrder.Id = -1;


      Assert.Equal(nullOrder.Items, testOrder.Items);
      Assert.Equal(nullOrder.Id, testOrder.Id);
      Assert.Equal(nullOrder.Price, testOrder.Price);
    }

    [Fact]
    public void TestStockReduction()
    {

      OrderTasks ot = new OrderTasks();
      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);

      int cheeseStock = testCheese.Stock;
      int maxCheese = Cheese.MaxStock;
      int expectedStock = maxCheese - 3;

      Assert.Equal(expectedStock, cheeseStock);
    }


    [Fact]
    public void TestStockReplenishAfterOrderCanceled()
    {
      OrderTasks ot = new OrderTasks();
      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);
      ot.CancelOrder(emptyOrder);

      int cheeseStock = testCheese.Stock;
      int maxCheese = Cheese.MaxStock;

      Assert.Equal(maxCheese, cheeseStock);
    }

    [Fact]
    public void TestRestock()
    {
      OrderTasks ot = new OrderTasks();
      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);

      int postOrder = testCheese.Stock;
      EmployeeTasks et = new EmployeeTasks();
      et.RestockProductGlobal(testCheese);
      int postRestock = testCheese.Stock;

      Assert.Equal(postOrder + 3, postRestock);
    }

    [Fact]
    public void TestCheckStock()
    {
      OrderTasks ot = new OrderTasks();
      List<Product> emptyItems = new List<Product>();
      Order emptyOrder = new Order(emptyItems);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);
      ot.AddProduct(emptyOrder, testCheese);

      CustomerTasks ct = new CustomerTasks();
      int postCheck = ct.CheckStock(testCheese);
      int realStock = testCheese.Stock;

      Assert.Equal(realStock, postCheck);
    }


    [Fact]
    public void TestAddToLocationInventory()
    {

      List<Product> testItems = new List<Product>();
      testItems.Add(testCheese);
      testItems.Add(testMilk);
      testItems.Add(testIceCream);

      Location loc = new Location();
      loc.AddToInventory(testCheese);
      loc.AddToInventory(testMilk);
      loc.AddToInventory(testIceCream);

      Assert.Equal(loc.Inventory, testItems);
    }

  }
}
