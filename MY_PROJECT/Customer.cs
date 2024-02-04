using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_PROJECT
{

    // Derived class for Customer implementing IDisplayable
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public void Display()
        {
            Console.WriteLine($"Customer ID: {Id,-5} | Name: {Name,-20} | Phone Number: {PhoneNumber}");
        }

    }
}
