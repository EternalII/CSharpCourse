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
            Vehicle vehDetails = null;
            Garage initVeh = new Garage();

            string vehType = askVehType(); // Ask user for vehicle type: bike, car, truck, etc...
            vehDetails = initVeh.initVehObject(vehType); // initialize correct object for user choice

            // ask tire pressure status
            System.Console.WriteLine(Environment.NewLine + "Enter tire pressure: ");
            enterWheelsData(ref vehDetails);
            //// for value testing: System.Console.WriteLine("Test: " + vehDetails.wheelsData.currAirPressure);

            questionnaire(vehType, ref vehDetails);

            return vehDetails;
        }

        public string askVehType()
        {
            var allVehTypes = Enum.GetValues(typeof(VehicleTypes));
            System.Console.WriteLine(Environment.NewLine + "Recognized vehicle types: ");
            foreach (var val in allVehTypes) // prints all available vehicle types reconigzed by garage
            {
                System.Console.Write(val + " ");
            }
            System.Console.WriteLine(Environment.NewLine + Environment.NewLine + "Enter vehicle type: ");
            string vehType = System.Console.ReadLine();
            vehType = vehType.ToLower();

            bool correctInputFlag = false;
            while (correctInputFlag == false)
            {
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

            return vehType;
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

        public void enterWheelsData(ref Vehicle veh)
        {
            string inputAirPressure = System.Console.ReadLine();
            float currAirPressure = float.Parse(inputAirPressure);

            veh.wheelsData = new WheelsData();
            veh.wheelsData.currAirPressure = currAirPressure;
        }

        public void questionnaire(string vehType, ref Vehicle veh)
        {

            switch (vehType)
            {
                case "bike":
                    askLicenseType(ref veh);
                    askEngineCapacity(ref veh);
                    break;
                case "elecbike":
                    askLicenseType(ref veh);
                    askEngineCapacity(ref veh);
                    break;
                //case "car":
                //    askCarColour(ref veh);
                //    askNumOfDoors(ref veh);
                //    break;
                //case "eleccar":
                //    askCarColour(ref veh);
                //    askNumOfDoors(ref veh);
                //    break;
                //case "truck":
                //    askHazMat(ref veh);
                //    askCargoVol(ref veh);
                //    break;
            }
        }

        void askLicenseType(ref Vehicle veh)
        {
            if (veh is Bike || veh is ElectricBike)
            {
                var bikeLicenses = Enum.GetValues(typeof(bikeLicenseTypes));
                foreach (var val in bikeLicenses) // prints all bike licenses
                {
                    System.Console.Write(val + " ");
                }
                System.Console.WriteLine(Environment.NewLine + Environment.NewLine + "Enter bike license type: ");
                string licenseType = System.Console.ReadLine();
                licenseType = licenseType.ToUpper();
                bool correctInputFlag = false;
                while (correctInputFlag == false)
                {
                    if (Enum.IsDefined(typeof(bikeLicenseTypes), licenseType))
                    {
                        correctInputFlag = true;
                    }
                    else // user has put incorrect vehicle type info that's not in the category
                    {
                        System.Console.WriteLine("Incorrect license, try again: ");
                        licenseType = System.Console.ReadLine();
                        licenseType = licenseType.ToUpper();
                    }
                }
                if (veh is Bike)
                {
                    Bike bike = veh as Bike;
                    bike.licenseType = licenseType;
                }
                else if (veh is ElectricBike)
                {
                    ElectricBike bike = veh as ElectricBike;
                    bike.licenseType = licenseType;
                }
            }
                
        }
        void askEngineCapacity(ref Vehicle veh)
        {
            string sCapacity;
            int capacity;
            System.Console.WriteLine("Enter bike engine capacity: ");
            sCapacity = System.Console.ReadLine();
            capacity = Int32.Parse(sCapacity);

            if (veh is Bike)
            {
                Bike bike = veh as Bike;
                bike.engineCapacity = capacity;
            }
            else if (veh is ElectricBike)
            {
                ElectricBike bike = veh as ElectricBike;
                bike.engineCapacity = capacity;
            }
        }

        //void askCarColour(ref Vehicle car)
        //{

        //}
    }
}