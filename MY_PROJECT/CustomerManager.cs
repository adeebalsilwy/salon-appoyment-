using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_PROJECT
{


    // Derived class for managing customers
    // Derived class for managing customers
    public class CustomerManager : EntityManager<Customer>
    {
        public bool IsCustomerExists(int customerId)
        {
            return entities.Any(c => c.Id == customerId);
        }
        public override void Add(Customer customer)
        {
            if (IsCustomerExists(customer))
            {
                Console.WriteLine("Customer with the same details already exists.");
                return;
            }

            customer.Id = entities.Count + 1;
            entities.Add(customer);
            SaveData();
            Console.WriteLine("Customer added successfully!");
        }

        public void Edit(int customerId, Customer updatedCustomer)
        {
            Customer existingCustomer = GetCustomerById(customerId);
            if (existingCustomer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            SaveData();
            Console.WriteLine("Customer updated successfully!");
        }

        public void Delete(int customerId)
        {
            Customer customerToDelete = GetCustomerById(customerId);
            if (customerToDelete == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            entities.Remove(customerToDelete);
            SaveData();
            Console.WriteLine("Customer deleted successfully!");
        }

        private Customer GetCustomerById(int customerId)
        {
            return entities.FirstOrDefault(c => c.Id == customerId);
        }

        private bool IsCustomerExists(Customer customer)
        {
            return entities.Any(c => c.Name.Equals(customer.Name, StringComparison.OrdinalIgnoreCase));
        }

        public override void Display()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("List of Customers:");
            Console.WriteLine("ID\tName\t\tPhone Number");
            foreach (var customer in entities)
            {
                Console.WriteLine($"{customer.Id}\t{customer.Name,-20}\t{customer.PhoneNumber}");
            }
            Console.WriteLine("-------------------------------------------------");
        }

        public override void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("customer_data.txt"))
            {
                foreach (var customer in entities)
                {
                    writer.WriteLine($"{customer.Id},{customer.Name},{customer.PhoneNumber}");
                }
            }
        }

        public override void LoadData()
        {
            if (File.Exists("customer_data.txt"))
            {
                string[] lines = File.ReadAllLines("customer_data.txt");
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    Customer customer = new Customer
                    {
                        Id = int.Parse(data[0]),
                        Name = data[1],
                        PhoneNumber = data[2]
                    };
                    entities.Add(customer);
                }
            }
        }
    }

}
