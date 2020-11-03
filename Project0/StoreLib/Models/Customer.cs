using StoreLib.Models;

namespace StoreLib.Models
{
    public class Customer:Person
    {
        public Customer(){
            Id = 0;
            Name = "Bob";
        }

        public Customer(string n, int i){
            Id = i;
            Name = n;
        }



    }
}