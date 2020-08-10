using API.Models;
using System;
using System.Threading;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Thread.Sleep(5000);
            CRUDManager cm = new CRUDManager();

            //cm.GetParks();
            //Thread.Sleep(2000);

            Park park = new Park()
            {
                ParkName = "12312313",
                ParkDescription = "Test Description",
                ParkCapacity = 1,
                ParkLocation = "Mums Basement"
            };

            //cm.AddPark(park);
            //Thread.Sleep(2000);

            cm.UpdatePark(6, park);
        }
    }
}
