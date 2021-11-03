using System;
using Spectre.Console;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace PragueParking2._0
{
    public static class StartupMenu
    {
        public static void Begin()
            {


            ConsoleKeyInfo input;
            do
            {
                Console.Clear();
                MenuLogo.MenuLogos();

                input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.P)
                {
                    ParkingHouse.AddVehicle();
                }
                if (input.Key == ConsoleKey.C)
                {
                    CheckoutVehicle.CheckoutVehicles();
                }
                if (input.Key == ConsoleKey.O)
                {
                    ParkingHouse.ListArray();
                }
                Console.WriteLine();

            } while (input.Key != ConsoleKey.Escape);

            Console.WriteLine("Exiting program...");
            Environment.Exit(0);

        }
    }
}
