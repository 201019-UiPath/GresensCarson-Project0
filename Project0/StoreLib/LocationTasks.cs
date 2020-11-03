using StoreLib.Models;
using System.Collections.Generic;

namespace StoreLib
{
    public class LocationTasks
    {

        public List<Order> GetOrderHistory(){
            //get order history of this location
            List<Order> lst = new List<Order>();
            return lst;
            // go to db and get order the recorded orders
        }

    }
}