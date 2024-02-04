using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_PROJECT
{

    // Derived class for Reservation implementing IDisplayable
    public class Reservation : Entity
    {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        public void Display()
        {
            Console.WriteLine($"Reservation ID: {Id,-5} - Date: {Date,-20} - Customer ID: {CustomerId}");
        }
    }

}
