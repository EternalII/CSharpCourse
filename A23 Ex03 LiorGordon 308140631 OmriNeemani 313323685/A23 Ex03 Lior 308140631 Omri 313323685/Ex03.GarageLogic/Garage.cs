using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage //This is a singletone so we can only have one dictionary of licenses in garage
    {
        private static Garage garageList = new Garage();
        public static Garage listVehicles
        {
            get { return garageList; }
        }
        
        private Dictionary<string, garageVehicle> licenseList = new Dictionary<string, garageVehicle>();
        private Garage()
        {

        }

        public bool isVehInGarage(string license)
        {
            garageVehicle data;
            bool licenseExists = licenseList.TryGetValue(license, out data);
            if (licenseExists)
            {
                return false;
            }

            return true;
        }
    }

    public class garageVehicle
    {
        string ownerName;
        int ownerPhone;
        string vehState = "In Repairs";
    }
    public class WheelsData
    {
        string manufacturer;
        float currAirPressure;
        float maxAirPressure;

        //fillAir(float amount)
        //{

        //    return fillng;
        //}
    }

    public abstract class Vehicle
    {
        string modelName;
        string licensePlate;
        float energyPercentage;
        WheelsData wheelsData = new WheelsData();
    }

    public enum FuelTypes
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }
    interface IFuel
    {
        FuelTypes fuelType { get; set; }
        float currLiters { get; }
        float maxLiters { get; }

        //refuel(float amount)
        //{

        //}
    }

    interface IElectric
    {
        string remainingBatteryTime { get; }
        string maxBatteryTime { get; }

        //recharge(float timeAdd)
        //{

        //}
    }

    public class Car : Vehicle, IFuel // missing IElectric
    {
        private float fuelAmount;
        public float currLiters{
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        private FuelTypes fType;

        public FuelTypes fuelType
        {
            get { return fType; }
            set { fType = value;  }
        }

        private float maxFuel;

        public float maxLiters
        {
            get { return maxLiters; }
            set { maxLiters = value; }
        }
    }
}

