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

    public enum vehStatus
    {
        inRepairs,
        repaired,
        paid
    }

    public enum bikeLicenseTypes
    {
        A,
        A1,
        AA,
        B
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
        string ownerName { get; set; } = "missing";
        int ownerPhone { get; set; } = 0;
        vehStatus vehState { get; set; } = vehStatus.inRepairs;
    }
    public class WheelsData
    {
        public string manufacturer { get; set; } = "N/A";
        public float currAirPressure { get; set; } = 0;
        public float maxAirPressure { get; set; } = 0;

        //fillAir(float amount)
        //{

        //    return fillng;
        //}
    }

    public abstract class Vehicle
    {
        public string modelName { get; set; }
        public string licensePlate { get; set; }
        public float energyPercentage { get; set; }
        public WheelsData wheelsData { get; set; }
        public garageVehicleStatus stats { get; set; }
    }


    public class Bike : Vehicle, IFuel
    {
        public string licenseType { get; set; }
        public int engineCapacity { get; set; }
        private FuelTypes fType;
        public FuelTypes fuelType
        {
            get { return fType; }
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
    }
    public class ElectricBike : Vehicle, IElectric
    {
        public string licenseType { get; set; }
        public int engineCapacity { get; set; }
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
    public class Car : Vehicle, IFuel
    {
        string colour { get; set; }
        int numOfDoors { get; set; }
        private FuelTypes fType;
        public FuelTypes fuelType
        {
            get { return fType; }
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
    }
    public class ElectricCar : Vehicle, IElectric
    {
        string colour { get; set; }
        int numOfDoors { get; set; }
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
    public class Truck : Vehicle, IFuel
    {
        bool hazardousMaterials { get; set; }
        float cargoVolume { get; set; }
        private FuelTypes fType;
        public FuelTypes fuelType
        {
            get { return fType; }
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
    }

    public class Garage
    {
        public Vehicle initVehObject(string vehType)
        {
            Vehicle vehObject = null;

            switch (vehType)
            {
                case "bike":
                    vehObject = new Bike();
                    break;
                case "elecbike":
                    vehObject = new ElectricBike();
                    break;
                case "car":
                    vehObject = new Car();
                    break;
                case "eleccar":
                    vehObject = new ElectricCar();
                    break;
                case "truck":
                    vehObject = new Truck();
                    break;
            }

            return vehObject;
        }
    }
}