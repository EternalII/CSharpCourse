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
            Dictionary<string, Vehicle> vehList = new Dictionary<string, Vehicle>(); // list of all vehicles. Should be turned into txt file later.
            RegisterVehicle clientVehicle = new RegisterVehicle(); // to use objects in console



            int loopFlag = 1;
            while (loopFlag == 1)
            {
                System.Console.WriteLine("Choose an option:");
                System.Console.WriteLine("[1]Register");
                System.Console.WriteLine("[2]ShowList");
                System.Console.WriteLine("[3]ChangeStatus");
                System.Console.WriteLine("[0]Exit]");
                string inputOption = System.Console.ReadLine();
                switch (inputOption)
                {
                    case "1":
                        string license = clientVehicle.enterLicense(vehList);
                        break;
                    case "2":
                        clientVehicle.showGarageList(vehList);
                        break;
                    case "3":
                        break;
                    case "0":
                        loopFlag = 0;
                        break;
                }
            }



        }
    }

    class RegisterVehicle
    {
        public string enterLicense(Dictionary<string, Vehicle> vehList)
        {
            System.Console.WriteLine("To enter vehicle into garage, please enter license number:");
            string license = System.Console.ReadLine();

            if (!vehList.ContainsKey(license))
            {
                Vehicle vehicle = fillVehDetails(license);
                //vehicle.stats.vehState = 0;

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

            return license;
        }

        public Vehicle fillVehDetails(string license)
        {
            //Vehicle vehDetails = null; in case l56 needs fixing
            Garage initVeh = new Garage();

            string vehType = askVehType(); // Ask user for vehicle type: bike, car, truck, etc...
            Vehicle vehDetails = initVeh.initVehObject(vehType); // initialize correct object for user choice

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

            try
            {
                float currAirPressure = float.Parse(inputAirPressure);
                veh.wheelsData = new WheelsData();
                veh.wheelsData.currAirPressure = currAirPressure;
            }
            catch (FormatException)
            {
                System.Console.WriteLine("{0} is not an integer", inputAirPressure);
                enterWheelsData(ref veh);
            }
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
                case "car":
                    askCarColour(ref veh);
                    askNumOfDoors(ref veh);
                    break;
                case "eleccar":
                    askCarColour(ref veh);
                    askNumOfDoors(ref veh);
                    break;
                case "truck":
                    askHazMat(ref veh);
                    askCargoVol(ref veh);
                    break;
            }
        }

        void askLicenseType(ref Vehicle veh)
        {
            if (veh is Bike || veh is ElectricBike)
            {
                var bikeLicenses = Enum.GetValues(typeof(BikeLicenseTypes));
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
                    if (Enum.IsDefined(typeof(BikeLicenseTypes), licenseType))
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

        void askCarColour(ref Vehicle veh)
        {
            System.Console.Write(Environment.NewLine + Environment.NewLine + "Enter car colour: [");
            var allVehTypes = Enum.GetValues(typeof(CarColours));
            foreach (var val in allVehTypes) // prints all available colours
            {
                System.Console.Write(val + " ");
            }
            System.Console.Write("]: ");
            string colour = System.Console.ReadLine();
            colour = colour.ToLower();


            if (veh is Car)
            {
                Car car = veh as Car;
                car.colour = colour;
            }
            else if (veh is ElectricCar)
            {
                ElectricCar car = veh as ElectricCar;
            }
        }

        void askNumOfDoors(ref Vehicle veh)
        {
            System.Console.WriteLine(Environment.NewLine + "Enter amount of doors in car: ");
            string stringNumOfDoors = System.Console.ReadLine();
            int.TryParse(stringNumOfDoors, out int numOfDoors);

            if (veh is Car)
            {
                Car car = veh as Car;
                car.numOfDoors = numOfDoors;
            }
            else if (veh is ElectricCar)
            {
                ElectricCar car = veh as ElectricCar;
                car.numOfDoors = numOfDoors;
            }
        }

        void askHazMat(ref Vehicle veh)
        {
            if (veh is Truck)
            {
                Truck truck = veh as Truck;

                System.Console.WriteLine(Environment.NewLine + "Does the truck carry hazardeous materials: [Yes / No]");
                string hasHazMat = System.Console.ReadLine();
                hasHazMat = hasHazMat.ToLower();
                if (hasHazMat == "yes") { truck.hazardousMaterials = true; }
                else { truck.hazardousMaterials = false; }
            }
        }

        void askCargoVol(ref Vehicle veh)
        {
            if (veh is Truck)
            {
                Truck truck = veh as Truck;

                System.Console.WriteLine(Environment.NewLine + "Enter cargo capacity: ");
                string sVolume = System.Console.ReadLine();
                float.TryParse(sVolume, out float truckVolume);

                truck.cargoVolume = truckVolume;
            }
        }

        public void showGarageList(Dictionary<string, Vehicle> vehList)
        {
            string showList = string.Format("{0,-35} {1,-20} \n", "License Number", "Status");

            foreach (KeyValuePair<string, Vehicle> veh in vehList)
            {
                showList += string.Format("{0,-35} {1,-20} \n", veh.Key, veh.Value.Stats.vehState.ToString());
            }

            System.Console.WriteLine(showList);
        }
    }
}