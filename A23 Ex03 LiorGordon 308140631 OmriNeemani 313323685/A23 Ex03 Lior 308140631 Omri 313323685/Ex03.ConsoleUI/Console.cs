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
            RegisterVehicle clientVehicle = new RegisterVehicle();

            string license = clientVehicle.enterLicense();

        }
    }

    class RegisterVehicle
    {
        public string enterLicense()
        {
            garageVehicle data;
            Garage licenseList = Garage.listVehicles;

            System.Console.WriteLine("To enter vehicle into garage, please enter license number:");
            string license = System.Console.ReadLine();

            bool inGarage = licenseList.isVehInGarage(license);
            if (inGarage)
            {
                System.Console.WriteLine("Vehicle already in garage, loading data . . .");
            }
            else
            {
                System.Console.WriteLine("Adding vehicle to the garage");
                //Add details about vehicle here
            }

            return license;
        }


    }
}
