using System;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace PragueParking2._0
{
    public class ParkingHouse
    {
        static Vehicle[,] vehicleArray = new Vehicle[100, 2];

        public static void AddVehicle()
        {
            
            string regNumber = AnsiConsole.Ask<string>("Please enter a license number: ");
            regNumber = regNumber.ToUpper();

            Vehicle.VehicleTypeEnum tempAddVehicle = GetVehicleType();

            var avTable = new Table().RoundedBorder()
                .BorderColor(Color.Green)
                .Border(TableBorder.DoubleEdge)
                .Title("PARKED VEHICLE");

            bool vehicleAdded = false; 

            Vehicle tempVehicle = new Vehicle(regNumber, tempAddVehicle, DateTime.Today);
            string[] tempSplit = tempVehicle.ToString("C").Split(" ");

            if (tempAddVehicle == Vehicle.VehicleTypeEnum.Car)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (vehicleArray[i, 0] == null && vehicleArray[i, 1] == null)
                    {
                        vehicleArray[i, 0] = tempVehicle;
                        avTable.AddColumn("[blue][bold]License plate[/][/]");
                        avTable.AddColumn("[blue][bold]Vehicle type[/][/]");
                        avTable.AddColumn("[blue][bold]Parking started[/][/]");
                        avTable.AddColumn("[blue][bold]Parking spot assigned[/][/]");
                        avTable.AddRow($"{tempSplit[0]}", $"{tempSplit[1]}", $"{tempSplit[2]}", $"{i + 1}");
                        Console.WriteLine();
                        AnsiConsole.Write(avTable);
                        vehicleAdded = true;
                        i = 100; 
                    }
                }
            }

            if (tempAddVehicle == Vehicle.VehicleTypeEnum.MC)
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (vehicleArray[i, 0] == null)
                        {
                            vehicleArray[i, 0] = tempVehicle;
                            avTable.AddColumn("[blue][bold]License plate[/][/]");
                            avTable.AddColumn("[blue][bold]Vehicle type[/][/]");
                            avTable.AddColumn("[blue][bold]Parking started[/][/]");
                            avTable.AddColumn("[blue][bold]Parking spot assigned[/][/]");
                            avTable.AddRow($"{tempSplit[0]}", $"{tempSplit[1]}", $"{tempSplit[2]}", $"{i + 1}");
                            Console.WriteLine();
                            AnsiConsole.Write(avTable);
                            vehicleAdded = true;
                        }

                        if (vehicleAdded == false)
                        {
                            if (vehicleArray[i, 0].VehicleTypes == Vehicle.VehicleTypeEnum.MC && vehicleArray[i, 1] == null)
                            {
                                vehicleArray[i, 1] = tempVehicle;
                                avTable.AddColumn("[blue][bold]License plate[/][/]");
                                avTable.AddColumn("[blue][bold]Vehicle type[/][/]");
                                avTable.AddColumn("[blue][bold]Parking started[/][/]");
                                avTable.AddColumn("[blue][bold]Parking spot assigned[/][/]");
                                avTable.AddRow($"{tempSplit[0]}", $"{tempSplit[1]}", $"{tempSplit[2]}", $"{i + 1}");
                                Console.WriteLine();
                                AnsiConsole.Write(avTable);
                                vehicleAdded = true;
                            }
                        }

                        if (vehicleAdded)
                        {
                            i = 100;
                            j = 2;
                        }
                    }
                }
            }

            if (!vehicleAdded)
            {
                Console.WriteLine("Parking house is full for your vehicle type. Come back again later.");
                Console.ReadLine();
            }
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Vehicle saveTempVehicle = vehicleArray[i, j];
                    WriteTmpFile(saveTempVehicle);
                }
            }

            WriteFile();                                                    

            Program.Approve(); 
            StartupMenu.Begin();
        }

        public static void ListArray()                                          // DESIGNA OM TABELLEN SÅ BLIR SNYGGARE OCH TYDLIGARE
        {
            for (int i = 0; i < 100; i++)
            {
                if (vehicleArray[i, 0] == null && vehicleArray[i, 1] == null)
                {
                    Console.WriteLine("Parking lot {0}: Empty", i + 1);
                }

                else
                {
                    if (vehicleArray[i, 0] != null)
                    {
                        Console.WriteLine("Parking lot {0}: ", i + 1);
                        Console.Write(vehicleArray[i, 0].VehicleTypes + " * ");
                        Console.Write("License plate: " + vehicleArray[i, 0].RegNumber + " * ");
                        Console.WriteLine("Vehicle parked: " + vehicleArray[i, 0].ParkTime);
                    }
                    if (vehicleArray[i, 0] == null)
                    {
                        Console.WriteLine("First half of parking lot {0}: Empty", i + 1);
                    }

                    if (vehicleArray[i, 1] != null)
                    {
                        Console.WriteLine("Parking lot {0}: ", i + 1);
                        Console.Write(vehicleArray[i, 1].VehicleTypes + " * ");
                        Console.Write("License plate: " + vehicleArray[i, 0].RegNumber + " * ");
                        Console.WriteLine("Vehicle parked: " + vehicleArray[i, 1].ParkTime);
                    }
                }
            }
            Program.Approve(); 
            StartupMenu.Begin();
        }

        static Vehicle.VehicleTypeEnum GetVehicleType()
        {
            Console.WriteLine();
            var vehicleType = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"What kind of [yellow]vehicle[/] are you parking?")
                    .AddChoices(new[]
                    {
                        "Motorcycle", "Car"
                    }));

            Vehicle.VehicleTypeEnum getVehicleType = Vehicle.VehicleTypeEnum.Car;

            if (vehicleType == "Motorcycle")
            {
                getVehicleType = Vehicle.VehicleTypeEnum.MC;
            }
            if (vehicleType == "Car")
            {
                getVehicleType = Vehicle.VehicleTypeEnum.Car;
            }

            return getVehicleType;
        }

        static void WriteTmpFile(Vehicle tempParking)
        {
            StreamWriter writeToFileTmp = new StreamWriter("arraytmp.txt", true);

            using (writeToFileTmp)
            {
                if (tempParking != null)
                {
                    writeToFileTmp.WriteLine(tempParking.VehicleTypes);
                    writeToFileTmp.WriteLine(tempParking.RegNumber);
                    writeToFileTmp.WriteLine(tempParking.ParkTime);
                }
                if (tempParking == null)
                {
                    writeToFileTmp.WriteLine();
                    writeToFileTmp.WriteLine();
                    writeToFileTmp.WriteLine();
                }
            }
        }

        static void WriteFile()
        {
            StreamWriter writeToFile = new StreamWriter("arraysavefile.txt", false);
            StreamReader readFileTmp = new StreamReader("arraytmp.txt");

            using (writeToFile)
            {
                using (readFileTmp)
                {
                    string tmp = readFileTmp.ReadLine();
                    while (tmp != null)
                    {
                        writeToFile.WriteLine(tmp);
                        tmp = readFileTmp.ReadLine();
                    }
                }
            }

            File.Delete("arraytmp.txt");
        }

        public static void GetArrayFile()
        {
            int lines = 0;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Vehicle temp = null;
                    temp = CopyFromSavedFile(lines);

                    if (temp != null)
                    {
                        vehicleArray[i, j] = temp;
                    }

                    if (temp == null)
                    {
                        vehicleArray[i, j] = null;
                    }
                    lines = lines + 3;
                }
            }
        }

        static Vehicle CopyFromSavedFile(int linesFile)
        {
            Vehicle tempVehicle = null;

            try
            {
                StreamReader saveFile = new StreamReader("arraysavefile.txt");

                try
                {
                    string vehicleTypeString = "";
                    string regNumber = "";
                    string timeStamp = "";

                    Vehicle.VehicleTypeEnum vehicleType = Vehicle.VehicleTypeEnum.MC;

                    using (saveFile)
                    {
                        int i = 0;

                        while (i <= linesFile)
                        {
                            vehicleTypeString = saveFile.ReadLine();
                            regNumber = saveFile.ReadLine();
                            timeStamp = saveFile.ReadLine();
                            i = i + 3; 
                        }
                    }
                    if (vehicleTypeString != "")
                    {
                        if (vehicleTypeString == "MC")
                        {
                            vehicleType = Vehicle.VehicleTypeEnum.MC;
                        }
                        if (vehicleTypeString == "Car")
                        {
                            vehicleType = Vehicle.VehicleTypeEnum.Car; 
                        }

                        DateTime parkTime = Convert.ToDateTime(timeStamp);

                        tempVehicle = new Vehicle(regNumber, vehicleType, parkTime);
                    }
                }

                finally
                {
                    saveFile.Close(); 
                }
            }

            catch (FileNotFoundException)
            {
                if (linesFile == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < 10; i++)                               
                    {
                        Console.WriteLine("*WARNING* The file could not be found, no vehicles from previous backup *WARNING*");
                        Thread.Sleep(50);
                        Console.Clear();
                        Thread.Sleep(50);
                    }
                    Console.WriteLine("*WARNING* The file could not be found, no vehicles from previous backup *WARNING*");
                    Console.ForegroundColor = ConsoleColor.Gray; 
                }
            }
            catch (DirectoryNotFoundException)
            {
                if(linesFile == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("*WARNING* The directory of the save file could not be found, no vehicles from previous backup has been added *WARNING");
                        Thread.Sleep(50);
                        Console.Clear();
                        Thread.Sleep(50);
                    }
                    Console.WriteLine("*WARNING* The directory of the save file could not be found, no vehicles from previous backup has been added *WARNING");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            catch
            {
                if (linesFile == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("*WARNING* No save data has been loaded. *WARNING");
                        Thread.Sleep(50);
                        Console.Clear();
                        Thread.Sleep(50);
                    }
                    Console.WriteLine("*WARNING* No save data has been loaded. *WARNING");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            Program.Approve();
            StartupMenu.Begin(); 
        }

        static void Receipt()
        {


        }
    }
}
