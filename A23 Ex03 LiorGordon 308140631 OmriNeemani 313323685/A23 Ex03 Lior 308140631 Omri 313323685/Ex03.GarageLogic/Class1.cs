using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Class1
    {


    }

    class WheelsData
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

