using System;
namespace StoreDB
{
  public class OutOfStockException : Exception
  {
    public string errorMessage;
    public OutOfStockException(string message)
    {
      errorMessage = message;
    }

    public OutOfStockException()
    {
      errorMessage = "Sorry! We're out of stock - please try again some other time!";
    }


  }
}