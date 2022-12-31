using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum FuelTypes
    {
        soler,
        octan95,
        octan96,
        octan98
    }

    public enum VehicleTypes
    {
        bike,
        elecbike,
        car,
        eleccar,
        truck
    }
    //public class Garage //This is a singletone so we can only have one dictionary of licenses in garage
    //{
    //    private static Garage garageList = new Garage();
    //    public static Garage listVehicles
    //    {
    //        get { return garageList; }
    //    }

    //    private Dictionary<string, garageVehicle> licenseList = new Dictionary<string, garageVehicle>();
    //    private Garage()
    //    {

    //    }

    //    public bool isVehInGarage(string license)
    //    {
    //        garageVehicle data;
    //        bool licenseExists = licenseList.TryGetValue(license, out data);
    //        if (licenseExists)
    //        {
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    public class garageVehicleStatus
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
        string licensePlaCate;
        float energyPercentage;
        WheelsData wheelsData = new WheelsData();
    }
    interface IFuel
    {
        FuelTypes fuelType { get; } // removed set
        float currLiters { get; set; }
        float maxLiters { get; }

        void refill(float amount);
    }

    interface IElectric
    {
        string remainingBatteryTime { get; set; }
        string maxBatteryTime { get; }

        void recharge(string timeAdd);
    }

    public class Car : Vehicle, IFuel, IElectric
    {

        // for regular fuel
        private FuelTypes fType;
        public FuelTypes fuelType
        {
            get { return fType; }
            // set { fType = value;  }
        }

        private float fuelAmount; // current fuel amount
        public float currLiters
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        private float mFuel; // max fuel amount
        public float maxLiters
        {
            get { return mFuel; }
        }

        public void refill(float liters)
        {
            float maxFuel = maxLiters;
            float currFuel = fuelAmount;

            float diff = maxFuel - (currFuel + liters);
            if (diff <= 0)
            {
                fuelAmount = maxFuel;
            }
            else
            {
                fuelAmount = currFuel + liters;
            }
        }

        // for battery car
        private string batTime;
        public string remainingBatteryTime
        {
            get { return batTime; }
            set { batTime = value; }
        }

        private string maxBatTime;
        public string maxBatteryTime
        {
            get { return maxBatTime; }
        }
        public void recharge(string timeAdd)
        {
            Int32.TryParse(timeAdd, out int intTimeAdd);
            Int32.TryParse(maxBatTime, out int intMaxBat);
            Int32.TryParse(batTime, out int currBatTime);

            float diff = intMaxBat - (currBatTime + intTimeAdd);
            if (diff <= 0)
            {
                remainingBatteryTime = intMaxBat.ToString();
            }
            else
            {
                remainingBatteryTime = (currBatTime + intTimeAdd).ToString();
            }
        }
    }
}

