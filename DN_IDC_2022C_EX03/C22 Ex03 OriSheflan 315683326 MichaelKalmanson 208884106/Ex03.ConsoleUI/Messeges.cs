using Ex03.GarageLogic;
using System.Text;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    internal class Messeges
    {
        public static string WelcomeMsg()
        {
            return string.Format(
@"Choose an action from the list below:
(1)  Enter new vehicle.
(2)  Show the list of vehicles.
(3)  Change vehicle status.
(4)  Inflate air in wheels to maximum.
(5)  Refueling a fuel driven vehicle.
(6)  Charging an electric vehicle.
(7)  Show all info on specific vehicle.
(8)  Exit.");
        }

        public static string EnterLicenseNumberMsg()
        {
            return "Please enter non-empty License Number";
        }

        public static string VehicleIsInGarageMsg()
        {
            return string.Format(
@"This vehicle is allready in the garage.
The status change to status: 'BeingRepaired'.");
        }

        public static string BasicInfoMsg()
        {
            return string.Format(
@"Please enter the following details:
(1) Vehicle owner name.
(2) Vehicle owner phone-number.
(3) The model of the car.");
        }

        public static string TypeOfVehicleMsg()
        {
            return EnumValuesToMsg(typeof(eVehicleType));
        }

        public static string WheelsInfo()
        {
            return string.Format(@"Please enter the following details:
1.Manufacturer Name
2.Current Air Pressure (PSI)");

        }

        public static string EnumValuesToMsg(Type i_Enum)
        {
            string[] enumListArray = Enum.GetNames(i_Enum);
            int enumListLength = enumListArray.Length;
            StringBuilder enumMsg = new StringBuilder();
            enumMsg.Append(String.Format("choose from the following:{0}", Environment.NewLine));

            for (int i = 0; i < enumListLength; i++)
            {
                enumMsg.Append(String.Format("({0}) {1}{2}", (i + 1).ToString(), enumListArray[i], Environment.NewLine));
            }

            return enumMsg.ToString();
        }

        public static string ChangeMethodNameToDisplayMsg(string i_Name)
        {
            int nameLength = i_Name.Length;
            bool weNeedToAddSpace;
            for (int i = 0; i < nameLength - 1; i++)
            {
                weNeedToAddSpace = char.IsLower(i_Name[i]) && char.IsUpper(i_Name[i + 1]);
                if (weNeedToAddSpace)
                {
                    i_Name = i_Name.Insert(i + 1, " ");
                }
            }

            return i_Name.ToLower();

        }

        public static string ShowListOfVehicleTypeMsg()
        {
            return EnumValuesToMsg(typeof(eStatusOfVehicle));
        }

        public static string ChooseVehicleToInflateWheelToMaxMsg()
        {
            return "Enter the license number of the vehicle in the garage you want to inflate his wheels to max and then press enter:";
        }

        public static string ChooseTypeOfFualMsg()
        {
            return EnumValuesToMsg(typeof(eFualType));
        }

        public static string ChooseHowMuchFualToFualong(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            string maxFualThatCanBeFilled = getMaxEnergyToFill(i_GarageManeger, i_LicenseNumber);
            return string.Format("Please Enter how much fual do you want to fill the tank with (within the range (0-{0})))", maxFualThatCanBeFilled);
        }

        public static string ChooseHowMuchToCharge(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            string maxElectricityThatCanBeCharged = getMaxEnergyToFill(i_GarageManeger, i_LicenseNumber);
            return String.Format("Please Enter how much time (in hours) to charge (within the range (0-{0}))", maxElectricityThatCanBeCharged);
        }

        private static string getMaxEnergyToFill (GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            Engine engine = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.M_Engine;
            return (engine.M_AmountOfMaxEnergy - engine.M_AmountOfEnergyLeftInTheEngine).ToString();
        }

        public static string ShowSpecialVehicleInfo(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            Vehicle vehicle = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle;
            StringBuilder specialInfo = new StringBuilder();
            specialInfo.Append(String.Format("{0}Other information-{0}", Environment.NewLine));
            List<MethodInfo> methodsForSpecificVehicle = i_GarageManeger.BuildMethodsForSpecificVehicle(vehicle, "get");

            foreach (MethodInfo uniqueMethod in methodsForSpecificVehicle)
            {
                var methodReturnValue = uniqueMethod.Invoke(vehicle, null);
                Type typeOfMethodReturnValue = methodReturnValue.GetType();
                bool specialField = (typeOfMethodReturnValue.IsEnum) || typeOfMethodReturnValue.Equals(typeof(int)) ||
                    typeOfMethodReturnValue.Equals(typeof(float)) || typeOfMethodReturnValue.Equals(typeof(bool));
                if (specialField)
                {
                    string specialFieldInfoMsg = string.Format("{0} : {1}{2}", ChangeMethodNameToDisplayMsg(uniqueMethod.Name.Remove(0, 6)), methodReturnValue.ToString(), Environment.NewLine);
                    specialInfo.Append(specialFieldInfoMsg);
                }
            }

            return specialInfo.ToString();
        }

        public static string ChooseCurrentAmountOfEnergy(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            string maxAmountOfEnergy = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.M_Engine.M_AmountOfMaxEnergy.ToString();
            return String.Format("Please enter the current amount of energy in the engine (within the range 0-{0}) and than press enter:", maxAmountOfEnergy);
        }

        public static string ShowGenericVehicleInfo(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            Vehicle vehicleToShow = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle;

            StringBuilder info = new StringBuilder();
            GarageNote garageNote = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber];
            string ownerName = garageNote.M_NameOfCarOwner;
            string phoneNumber = garageNote.M_PhoneNumberOfCarOwner;
            eStatusOfVehicle statusOfVehicl = garageNote.M_StateOfVehicle;
            string model = vehicleToShow.M_Model;
            string infoWheels = GetInfoAboutWheels(vehicleToShow.M_WheelsList);
            string infoEngine = GetInfoAboutEngine(vehicleToShow.M_Engine);


            info.Append(string.Format(
@"General information-
License Number: {0}
Owner name: {1}
Phone number: {2}
Vehicle status: {3}
Vehicle model: {4}
{5}
{6}", i_LicenseNumber, ownerName, phoneNumber, statusOfVehicl, model, infoWheels, infoEngine));
            return info.ToString();
        }

        private static string GetInfoAboutWheels(List<Wheel> i_Wheels)
        {
            StringBuilder wheelsInfo = new StringBuilder();
            int i = 1;
            foreach (Wheel wheel in i_Wheels)
            {
                wheelsInfo.Append(string.Format(
@"Wheels information-
Wheel number {0} -->
Manufacture name: {1}
Current amount of pressure: {2}
Max air pressure: {3}", i, wheel.M_ManufacturerName, wheel.M_CurrentAirPressurePSI, wheel.M_MaxAirPressurePSI));
                wheelsInfo.Append(Environment.NewLine);
                i += 1;
            }

            return wheelsInfo.ToString();

        }

        private static string GetInfoAboutEngine(Engine i_Engine)
        {
            return string.Format(
@"Engine information-
Amount of energy left in the engine: {0}
Max amount of energy in the engine: {1}", i_Engine.M_AmountOfEnergyLeftInTheEngine, i_Engine.M_AmountOfMaxEnergy);
        }
    }
}
