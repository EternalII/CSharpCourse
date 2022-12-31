using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Console
    {
        public static void Main()
        {
            Dictionary<string, object> vehList = new Dictionary<string, object>();
            RegisterVehicle clientVehicle = new RegisterVehicle();

            string license = clientVehicle.enterLicense(vehList);


        }
    }

    class RegisterVehicle
    {
        public string enterLicense(Dictionary<string, object> vehList)
        {
            System.Console.WriteLine("To enter vehicle into garage, please enter license number:");
            string license = System.Console.ReadLine();

            if (!vehList.ContainsKey(license))
            {
                object vehicle = fillVehDetails(license);
                try
                {
                    vehList.Add(license, vehicle);
                }
                catch (ArgumentException)
                {
                    System.Console.WriteLine("An element with license number = \"license\" already exists.");
                }
            }
            else
            {
                System.Console.WriteLine("Already in system");
            }


            //bool inGarage = licenseList.isVehInGarage(license);
            //if (inGarage)
            //{
            //    System.Console.WriteLine("Vehicle already in garage, loading data . . .");
            //}
            //else
            //{
            //    System.Console.WriteLine("Adding vehicle to the garage");
            //    //Add details about vehicle here
            //}
            return license;
        }

        public object fillVehDetails(string license)
        {
            var vehDetails = new Car(); //Will be a car by default
            // Ask user for vehicle type: bike, car, truck, etc...
            var allVehTypes = Enum.GetValues(typeof(VehicleTypes));
            System.Console.WriteLine(Environment.NewLine + "Recognized vehicle types: ");
            foreach (var val in allVehTypes) // prints all available vehicle types reconigzed by garage
            {
                System.Console.Write(val+" ");
            }
            System.Console.WriteLine(Environment.NewLine + Environment.NewLine + "Enter vehicle type: ");
            string vehType = System.Console.ReadLine();
            vehType = vehType.ToLower();

            bool correctInputFlag = false;
            while (correctInputFlag == false) {
                if (Enum.IsDefined(typeof(VehicleTypes), vehType))
                {
                    correctInputFlag = true;
                }
                else // user has put incorrect vehicle type info that's not in the category
                {
                    System.Console.WriteLine("Incorrect vehicle type, try again: ");
                    vehType = System.Console.ReadLine();
                    vehType = vehType.ToLower();
                }
            }

            // move part below to Garage.cs
            switch (vehType)
            {
                case "bike":
                    break;
                case "elecbike":
                    break;
                case "car":
                    vehDetails = new Car();
                    vehDetails.currLiters = currFuel();
                    break;
                case "eleccar":
                    vehDetails = new Car();
                    vehDetails.remainingBatteryTime = currBatTime();
                    break;
                case "truck":
                    break;
            }

            return vehDetails;
        }


        public float currFuel()
        {
            System.Console.WriteLine("Current amount of fuel left:");
            string sCurrFuel = System.Console.ReadLine();
            float.TryParse(sCurrFuel, out float currFuel);

            return currFuel;
        }

        public string currBatTime()
        {
            System.Console.WriteLine("Current amount of battery time left in hours:");
            string currBatTime = System.Console.ReadLine();

            return currBatTime;
        }
        public float askToRefill()
        {
            System.Console.WriteLine("Amount to refill:");
            string sAddedFuel = System.Console.ReadLine();
            float.TryParse(sAddedFuel, out float addedFuel);

            return addedFuel;
        }

        public string askToRecharge()
        {
            System.Console.WriteLine("Amount to recharge:");
            string addBatTime = System.Console.ReadLine();

            return addBatTime;
        }
    }
}
