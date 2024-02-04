using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY_PROJECT
{
    public class ReservationManager : EntityManager<Reservation>
    {
        private CustomerManager customerManager; // Add this field to access the CustomerManager

        public ReservationManager()
        {
            customerManager = new CustomerManager(); // Initialize the CustomerManager
        }
       
        public override void Add(Reservation reservation)
        {
            if (!customerManager.IsCustomerExists(reservation.CustomerId))
            {
                Console.WriteLine("Customer does not exist. Please add the customer first.");
                return;
            }

            reservation.Id = entities.Count + 1;
            entities.Add(reservation);
            SaveData();
            Console.WriteLine("Reservation added successfully!");
        }


        public void Edit(int reservationId, Reservation updatedReservation)
        {
            try
            {
                Reservation existingReservation = GetReservationById(reservationId);
                if (existingReservation == null)
                {
                    Console.WriteLine("Reservation not found.");
                    return;
                }

                existingReservation.Date = updatedReservation.Date;
                existingReservation.CustomerId = updatedReservation.CustomerId;
                SaveData();
                Console.WriteLine("Reservation updated successfully!");
            }catch (Exception ex)
            {

            }
        }

        public void Cancel(int reservationId)
        {
            Reservation reservationToCancel = GetReservationById(reservationId);
            if (reservationToCancel == null)
            {
                Console.WriteLine("Reservation not found.");
                return;
            }

            entities.Remove(reservationToCancel);
            SaveData();
            Console.WriteLine("Reservation canceled successfully!");
        }

        private Reservation GetReservationById(int reservationId)
        {
            return entities.FirstOrDefault(r => r.Id == reservationId);
        }

        public override void Display()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("List of Reservations:");
            Console.WriteLine("ID\tDate\t\tCustomer ID");
            foreach (var reservation in entities)
            {
                Console.WriteLine($"{reservation.Id}\t{reservation.Date}\t{reservation.CustomerId}");
            }
            Console.WriteLine("-------------------------------------------------");
        }

        public override void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("reservation_data.txt"))
            {
                foreach (var reservation in entities)
                {
                    writer.WriteLine($"{reservation.Id},{reservation.Date},{reservation.CustomerId}");
                }
            }
        }

        public override void LoadData()
        {
            if (File.Exists("reservation_data.txt"))
            {
                string[] lines = File.ReadAllLines("reservation_data.txt");
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    Reservation reservation = new Reservation
                    {
                        Id = int.Parse(data[0]),
                        Date = DateTime.Parse(data[1]),
                        CustomerId = int.Parse(data[2])
                    };
                    entities.Add(reservation);
                }
            }
        }
    }

}

