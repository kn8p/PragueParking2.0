using System;
using Terminal.Gui;
using NStack;
using Spectre.Console;
using System.Threading.Tasks;
//using System.Threading;
using System.Linq;
using System.Text;
using System.Timers;



namespace PragueParking2._0
{
    class Program
    {

        public static void Main(string[] args)
        {


            //int startUpTime = 2000;
            //Vehicle.VehicleTypeEnum Bicycle = Vehicle.VehicleTypeEnum.Bike;               // Not yet
            //Vehicle.VehicleTypeEnum MC = Vehicle.VehicleTypeEnum.MC;
            //Vehicle.VehicleTypeEnum Car = Vehicle.VehicleTypeEnum.Car;
            //Vehicle.VehicleTypeEnum Bus = Vehicle.VehicleTypeEnum.Bus;                    // Not yet

            //Thread.Sleep(startUpTime);


            StartupMenu.Begin();


            //AnimatedStartup.Begin();

        }

        private static bool Quit()
        {
            throw new NotImplementedException();
        }

        public static void Approve()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey(); 
        }
    }
}
    
