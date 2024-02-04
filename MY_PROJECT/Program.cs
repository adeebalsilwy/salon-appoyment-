using MY_PROJECT;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        CustomerManager customerManager = new CustomerManager();
        ReservationManager reservationManager = new ReservationManager();

        while (true)
        {
            Console.WriteLine("1. Add a new customer");
            Console.WriteLine("2. Display list of customers");
            Console.WriteLine("3. Edit customer details");
            Console.WriteLine("4. Delete customer");
            Console.WriteLine("5. Make a new reservation");
            Console.WriteLine("6. Display list of reservations");
            Console.WriteLine("7. Edit reservation");
            Console.WriteLine("8. Cancel reservation");
            Console.WriteLine("9. Exit");

            Console.Write("Please choose an option: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Add a new customer
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Phone Number: ");
                    string phoneNumber = Console.ReadLine();
                    Customer newCustomer = new Customer { Name = name, PhoneNumber = phoneNumber };
                    customerManager.Add(newCustomer);
                    break;

                case 2:
                    // Display list of customers
                    customerManager.Display();
                    break;

                case 3:
                    // Edit customer details
                    EditCustomer(customerManager);
                    break;

                case 4:
                    // Delete customer
                    DeleteCustomer(customerManager);
                    break;

                case 5:
                    // Make a new reservation
                    MakeNewReservation(customerManager, reservationManager);
                    break;

                case 6:
                    // Display list of reservations
                    reservationManager.Display();
                    break;

                case 7:
                    // Edit reservation
                    EditReservation(reservationManager);
                    break;

                case 8:
                    // Cancel reservation
                    CancelReservation(reservationManager);
                    break;

                

                case 9:
                    // Exit
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void EditCustomer(CustomerManager customerManager)
    {
        Console.Write("Enter customer ID to edit: ");
        if (!int.TryParse(Console.ReadLine(), out int customerId))
        {
            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            return;
        }

        Customer updatedCustomer = GetCustomerDetails();
        customerManager.Edit(customerId, updatedCustomer);
    }

    private static void DeleteCustomer(CustomerManager customerManager)
    {
        Console.Write("Enter customer ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int customerIdToDelete))
        {
            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            return;
        }

        customerManager.Delete(customerIdToDelete);
    }

    private static void MakeNewReservation(CustomerManager customerManager, ReservationManager reservationManager)
    {
        // Make a new reservation
        customerManager.Display();
        Console.Write("Choose customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int customerIdForReservation))
        {
            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            return;
        }

        Console.Write("Reservation Date (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date.");
            return;
        }

        Reservation newReservation = new Reservation { CustomerId = customerIdForReservation, Date = date };
        reservationManager.Add(newReservation);
    }

    private static void EditReservation(ReservationManager reservationManager)
    {
        Console.Write("Enter reservation ID to edit: ");
        if (!int.TryParse(Console.ReadLine(), out int reservationId))
        {
            Console.WriteLine("Invalid input. Please enter a valid reservation ID.");
            return;
        }

        Reservation updatedReservation = GetReservationDetails();
        reservationManager.Edit(reservationId, updatedReservation);
    }

    private static void CancelReservation(ReservationManager reservationManager)
    {
        Console.Write("Enter reservation ID to cancel: ");
        if (!int.TryParse(Console.ReadLine(), out int reservationIdToDelete))
        {
            Console.WriteLine("Invalid input. Please enter a valid reservation ID.");
            return;
        }

        reservationManager.Cancel(reservationIdToDelete);
    }

   


    private static Customer GetCustomerDetails()
    {
        Console.Write("Enter updated Name: ");
        string updatedName = Console.ReadLine();
        Console.Write("Enter updated Phone Number: ");
        string updatedPhoneNumber = Console.ReadLine();

        return new Customer { Name = updatedName, PhoneNumber = updatedPhoneNumber };
    }

    private static Reservation GetReservationDetails()
    {
        Console.Write("Enter updated Date (YYYY-MM-DD): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime updatedDate))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date.");
            return null;
        }

        Console.Write("Enter updated Customer ID: ");
        if (!int.TryParse(Console.ReadLine(), out int updatedCustomerId))
        {
            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
            return null;
        }

        return new Reservation { Date = updatedDate, CustomerId = updatedCustomerId };
    }
}
