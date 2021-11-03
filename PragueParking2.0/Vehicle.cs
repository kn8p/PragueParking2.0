using System;
namespace PragueParking2._0
{
    public class Vehicle
    {
        private string _regNumber;
        private VehicleTypeEnum _vehicleTypes;
        private DateTime _parkTime;

        public Vehicle()
        {

        }

        public Vehicle(string regNumber, VehicleTypeEnum vehicleTypes, DateTime parkTime)
        {
            _regNumber = regNumber;
            _vehicleTypes = vehicleTypes;
            _parkTime = parkTime;
        }

        public string RegNumber { get { return _regNumber; } }

        public VehicleTypeEnum VehicleTypes { get { return _vehicleTypes; } }

        public DateTime ParkTime { get { return _parkTime; } }


        public string ToString(string fmt)
        {
            if (string.IsNullOrEmpty(fmt))
                fmt = "G";

            switch (fmt.ToUpperInvariant())
            {
                case "C":
                    return string.Format("{0} {1} {2} ", _regNumber, _vehicleTypes, _parkTime);

                default:
                    string msg = string.Format("'{0}' is an invalid format string", fmt);

                    throw new ArgumentException(msg);
            }
            
        }

        public enum VehicleTypeEnum
        {
            MC = 2, Car = 3
        }

    }





}
