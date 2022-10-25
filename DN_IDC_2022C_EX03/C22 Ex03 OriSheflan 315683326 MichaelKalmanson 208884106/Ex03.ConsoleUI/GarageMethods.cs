using Ex03.GarageLogic;
using System.Xml;
using System.Reflection;

namespace Ex03.ConsoleUI
{
    public class GarageMethods
    {
        public static void InsertNewVehicle(GarageManeger i_GarageManeger)
        {
            Console.WriteLine(Messeges.EnterLicenseNumberMsg());
            string licenseNumber = GetLicenseNumberFromUser();
            if (i_GarageManeger.IsVehicleInGarage(licenseNumber))
            {
                i_GarageManeger.ChangeCarStatus(licenseNumber, eStatusOfVehicle.BeingRepaired);
                Console.WriteLine(Messeges.VehicleIsInGarageMsg());
            }
            else
            {
                InsertNewVehicleHelper(i_GarageManeger, licenseNumber);
                Console.WriteLine("New vehicle was added successfully!");
                Thread.Sleep(1000);
            }
        }

        public static void ShowListOfVehicle(GarageManeger i_GarageManeger)
        {
            Console.WriteLine("Do you want to filter by vehicle type? enter y/n");
            string yesOrNo;
            do
            {
                yesOrNo = Console.ReadLine();
            }
            while (!CheckValidInput.YesOrNoInput(yesOrNo));
            if (yesOrNo == "n")
            {
                PrintListOfVehicle(i_GarageManeger.ShowVehiclesInTheGarageByCurrentStatus());
            }
            else
            {
                Console.WriteLine(Messeges.ShowListOfVehicleTypeMsg());
                int optionOfFiltering = GetOptionOfVehicleStatus();
                PrintListOfVeicleWithFilteringOption(i_GarageManeger, optionOfFiltering);
            }
        }

        public static void ChangeStatusOfVehicle(GarageManeger i_GarageManeger)
        {
            Console.WriteLine(Messeges.EnterLicenseNumberMsg());
            string licenseNumber = GetLicenseNumberFromUser();
            Console.WriteLine(Messeges.ShowListOfVehicleTypeMsg());
            int optionOfVehicleStatus = GetOptionOfVehicleStatus();
            ChangeStatusOfVehicle(i_GarageManeger, licenseNumber, optionOfVehicleStatus);
        }

        public static void InflateWheelsToMax(GarageManeger i_GarageManeger)
        {
            Console.WriteLine(Messeges.ChooseVehicleToInflateWheelToMaxMsg());
            Console.WriteLine(Messeges.EnterLicenseNumberMsg());
            string licenseNumber = GetLicenseNumberFromUser();
            if (!i_GarageManeger.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("This vehcle is not in the garage so you can't inflate nothing.");
            }
            else
            {
                i_GarageManeger.InflateWheelsToMax(licenseNumber);
            }
        }

        public static void FualingFualVehicle(GarageManeger i_GarageManeger)
        {
            Console.WriteLine(Messeges.EnterLicenseNumberMsg());
            string licenseNumber = GetLicenseNumberFromUser();
            if (!i_GarageManeger.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("This vehicle is not in the garage.");
            }
            else if (!i_GarageManeger.IsFualEngine(licenseNumber))
            {
                Console.WriteLine("This vehicle have an electeic engine, you can't fual it.");
            }
            else
            {
                Console.WriteLine(Messeges.EnumValuesToMsg(typeof(eFualType)));
                int typeOfFual = GetTypeOfFualToFualing();
                eFualType fualTypeToFualing = IntToFualType(typeOfFual);
                Console.WriteLine(Messeges.ChooseHowMuchFualToFualong(i_GarageManeger, licenseNumber));
                float amountOfFual = GetAmountOfEnergyFromUser();
                i_GarageManeger.FillFualInVehicle(licenseNumber, fualTypeToFualing, amountOfFual);
                Console.WriteLine("Fualed succesfully!");
            }
        }

        public static void CharginElectricVehicle(GarageManeger i_GarageManeger)
        {
            Console.WriteLine(Messeges.EnterLicenseNumberMsg());
            string licenseNumber = GetLicenseNumberFromUser();
            if (!i_GarageManeger.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("This vehicle is not in the garage.");
            }
            else if (i_GarageManeger.IsFualEngine(licenseNumber))
            {
                Console.WriteLine("This vehicle have an Fual engine, you can't charge it.");
            }
            else
            {
                Console.WriteLine(Messeges.ChooseHowMuchToCharge(i_GarageManeger, licenseNumber));
                float amountOfFual = GetAmountOfEnergyFromUser();
                i_GarageManeger.ChargeVehicle(licenseNumber, amountOfFual);
                Console.WriteLine("Charged successfully!");
            }
        }

        public static void ShowInfoOnVehicle(GarageManeger i_GarageManeger)
        {
            Console.WriteLine(Messeges.EnterLicenseNumberMsg());
            string licenseNumber = GetLicenseNumberFromUser();
            Console.WriteLine(Messeges.ShowGenericVehicleInfo(i_GarageManeger, licenseNumber));
            Console.WriteLine(Messeges.ShowSpecialVehicleInfo(i_GarageManeger, licenseNumber));
        }

        public static string GetLicenseNumberFromUser()
        {
            string licenseNumber = Console.ReadLine();
            while (!CheckValidInput.LicenseNumberInput(licenseNumber))
            {
                licenseNumber = Console.ReadLine();
            }
            return licenseNumber;
        }

        public static void InsertNewVehicleHelper(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            string nameOfVehicleOwner, phoneNumberOfVehicleOwner, VehicleModel, typeOfVehicle;
            GetBasicInfo(out nameOfVehicleOwner, out phoneNumberOfVehicleOwner, out VehicleModel, out typeOfVehicle);
            eVehicleType VehicleType = (eVehicleType)(int.Parse(typeOfVehicle) - 1);
            i_GarageManeger.AddNewVehicle(nameOfVehicleOwner, phoneNumberOfVehicleOwner, VehicleType, VehicleModel, i_LicenseNumber);
            Vehicle newVehicle = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle;
            Console.Clear();
            SetWheels(i_GarageManeger, i_LicenseNumber);
            Console.Clear();
            SetCurrentAmountOfEnergyInEngine(i_GarageManeger, i_LicenseNumber);
            SetEnergyPrecentageForVehicle(i_GarageManeger, i_LicenseNumber);
            Console.Clear();
            FillDataForVehicle(newVehicle, i_GarageManeger);
        }

        public static void GetBasicInfo(out string o_NameOfVehicleOwner, out string o_PhoneNumberOfVehicleOwner, out string o_VehicleModel,
            out string i_TypeOfVehicle)
        {
            bool isFirstTime = true;
            do
            {
                if (!isFirstTime)
                {
                    Console.Clear();
                    Console.WriteLine("One or more of the inputs are not valid, please try again:");
                }
                Console.WriteLine(Messeges.BasicInfoMsg());
                o_NameOfVehicleOwner = Console.ReadLine();
                o_PhoneNumberOfVehicleOwner = Console.ReadLine();
                o_VehicleModel = Console.ReadLine();

                Console.WriteLine(Messeges.TypeOfVehicleMsg());
                i_TypeOfVehicle = Console.ReadLine();

                isFirstTime = false;
            }
            while (!CheckValidInput.CheckNonEmptyInput(o_NameOfVehicleOwner) || !CheckValidInput.IsInt(o_PhoneNumberOfVehicleOwner)
            || !CheckValidInput.CheckNonEmptyInput(o_VehicleModel) || !CheckValidInput.TypeOfVehicle(i_TypeOfVehicle));
        }

        public static void SetWheels(GarageManeger i_GarageManeger, string i_licenseNumber)
        {
            string setWheelsOneByOne;
            Console.WriteLine("Do you want to set the wheels one by one? enter: y/n:");
            do
            {
                setWheelsOneByOne = Console.ReadLine();
            }
            while (!CheckValidInput.YesOrNoInput(setWheelsOneByOne));

            string manufacturerName;
            float currentAirPressurePSI;
            float? maxAirPressurePSI = i_GarageManeger.M_GarageVehcleDictionary[i_licenseNumber].M_Vehicle.M_WheelsList[0].M_MaxAirPressurePSI;

            GetParametersToWheelsFromUser(out manufacturerName, out currentAirPressurePSI, maxAirPressurePSI);
            int i = 0;
            foreach (Wheel wheel in i_GarageManeger.M_GarageVehcleDictionary[i_licenseNumber].M_Vehicle.M_WheelsList)
            {
                wheel.M_ManufacturerName = manufacturerName;
                wheel.M_CurrentAirPressurePSI = currentAirPressurePSI;


                if (setWheelsOneByOne == "y" && i != i_GarageManeger.M_GarageVehcleDictionary[i_licenseNumber].M_Vehicle.M_WheelsList.Count - 1)
                {
                    GetParametersToWheelsFromUser(out manufacturerName, out currentAirPressurePSI, maxAirPressurePSI);
                }
                i += 1;
            }
        }

        public static void GetParametersToWheelsFromUser(out string manufacturerName, out float currentAirPressurePSI, float? maxAirPressurePSI)
        {
            string strCurrentAirPressurePSI;
            do
            {
                Console.WriteLine(Messeges.WheelsInfo());
                manufacturerName = Console.ReadLine();
                strCurrentAirPressurePSI = Console.ReadLine();
            }
            while (!CheckValidInput.InputForWheelsInfo(manufacturerName, strCurrentAirPressurePSI, maxAirPressurePSI));

            currentAirPressurePSI = float.Parse(strCurrentAirPressurePSI);

        }

        public static void FillDataForVehicle(Vehicle i_Vehicle, GarageManeger i_GarageManeger)
        {
            List<MethodInfo> methodsForSpecificVehicle = i_GarageManeger.BuildMethodsForSpecificVehicle(i_Vehicle, "set");
            float userInput;
            object[] methodParams = new object[1];
            string msgForChoosingParam = string.Empty;
            string listOfParamsToChooseFrom = string.Empty;

            foreach (MethodInfo uniqueMethod in methodsForSpecificVehicle)
            {
                Type typeOfParam = uniqueMethod.GetParameters()[0].ParameterType;
                if (typeOfParam.Equals(typeof(bool)))
                {
                    msgForChoosingParam = string.Format("Choose whether {0} :", Messeges.ChangeMethodNameToDisplayMsg(uniqueMethod.Name.Remove(0, 6)));
                    listOfParamsToChooseFrom = string.Format("{0}(1) Yes{0}(2) No", Environment.NewLine);
                    Console.WriteLine(msgForChoosingParam);
                    Console.WriteLine(listOfParamsToChooseFrom);
                    userInput = GetUserAnswer((1, 2));
                    if (userInput == 1)
                    {
                        methodParams[0] = true;
                    }
                    else
                    {
                        methodParams[0] = false;
                    }
                }
                else if (typeOfParam.IsEnum)
                {
                    msgForChoosingParam = string.Format("Choose {0} :", Messeges.ChangeMethodNameToDisplayMsg(typeOfParam.Name.ToString().Remove(0,1)));
                    listOfParamsToChooseFrom = Messeges.EnumValuesToMsg(typeOfParam);
                    Console.WriteLine(msgForChoosingParam);
                    Console.WriteLine(listOfParamsToChooseFrom);
                    float numOfEnumOptions = Enum.GetNames(typeOfParam).Length;
                    userInput = GetUserAnswer((1, numOfEnumOptions));
                    methodParams[0] = (int)(userInput - 1);
                }
                else if (typeOfParam.Equals(typeof(int)) || typeOfParam.Equals(typeof(float)))
                {
                    msgForChoosingParam = string.Format("Choose {0}:", Messeges.ChangeMethodNameToDisplayMsg(uniqueMethod.Name.Remove(0, 6)));
                    Console.WriteLine(msgForChoosingParam);
                    userInput = GetUserAnswer((1, float.MaxValue));
                    if (typeOfParam.Equals(typeof(int)))
                    {
                        methodParams[0] = (int)userInput;
                    }
                    else
                    {
                        methodParams[0] = userInput;
                    }
                }
                else
                {
                    break;
                }

                uniqueMethod.Invoke(i_Vehicle, methodParams);
            }
        }

        private static float getUserInput()
        {
            string userInput = Console.ReadLine();
            while (!CheckValidInput.IsFloat(userInput))
            {
                Console.WriteLine("Please try again:");
                userInput = Console.ReadLine();
            }
            float floatUserInput = float.Parse(userInput);
            return floatUserInput;
        }

        private static float GetUserAnswer((float, float) i_Range)
        {
            float userInput = getUserInput();
            while (!CheckValidInput.CheckIfInputIsInRange(userInput, i_Range))
            {
                Console.WriteLine("Please try again:");
                userInput = getUserInput();
            }

            return userInput;
        }

        private static int GetOptionOfVehicleStatus()
        {
            string inputOption;
            do
            {
                inputOption = Console.ReadLine();
            }
            while (!CheckValidInput.InputForVehicleStatus(inputOption));

            return int.Parse(inputOption);
        }

        private static void PrintListOfVeicleWithFilteringOption(GarageManeger i_GarageManeger, int i_OptionOfFiltering)
        {
            eStatusOfVehicle statusOfVehcle = IntToStatusOfVehcle(i_OptionOfFiltering);
            Dictionary<string, eStatusOfVehicle> vehiclesInTheGarageByCurrentStatus;
            vehiclesInTheGarageByCurrentStatus = i_GarageManeger.ShowVehiclesInTheGarageByCurrentStatus(statusOfVehcle);
            PrintListOfVehicle(vehiclesInTheGarageByCurrentStatus);
        }

        private static void PrintListOfVehicle(Dictionary<string, eStatusOfVehicle> i_VehiclesInTheGarageByCurrentStatus)
        {
            if (i_VehiclesInTheGarageByCurrentStatus.Count > 0)
            {
                Console.WriteLine("The list of license number: ");
                int i = 1;
                foreach (var item in i_VehiclesInTheGarageByCurrentStatus)
                {
                    Console.WriteLine(string.Format("{0}. LicenseNumber: {1}", i, item.Key).ToString());
                    i += 1;
                }
            }
            else
            {
                Console.WriteLine("No vehicles in garage with that status.");
            }
        }

        private static void ChangeStatusOfVehicle(GarageManeger i_GarageManeger, string i_licenseNumber, int i_optionOfVehicleStatus)
        {
            if (!i_GarageManeger.IsVehicleInGarage(i_licenseNumber))
            {
                Console.WriteLine("This vehicle is not in the garage, so you can't change the status.");
            }
            else
            {
                eStatusOfVehicle statusOfVehicle = IntToStatusOfVehcle(i_optionOfVehicleStatus);
                i_GarageManeger.ChangeCarStatus(i_licenseNumber, statusOfVehicle);
                Console.WriteLine("The status has been changed succesfully!");
            }
        }

        private static eStatusOfVehicle IntToStatusOfVehcle(int i_OptionOfVehicleStatus)
        {
            eStatusOfVehicle statusOfVehicle;
            if (i_OptionOfVehicleStatus == 1)
            {
                statusOfVehicle = eStatusOfVehicle.BeingRepaired;
            }
            else if (i_OptionOfVehicleStatus == 2)
            {
                statusOfVehicle = eStatusOfVehicle.Fixed;
            }
            else
            {
                statusOfVehicle = eStatusOfVehicle.Paid;
            }

            return statusOfVehicle;
        }

        private static int GetTypeOfFualToFualing()
        {
            string inputOption;
            do
            {
                inputOption = Console.ReadLine();
            }
            while (!CheckValidInput.InputForFualType(inputOption));

            return int.Parse(inputOption);
        }

        private static eFualType IntToFualType(int i_TypeOfFual)
        {
            string[] enumListArray = Enum.GetNames(typeof(eFualType));
            int enumListLength = enumListArray.Length;
            eFualType fualType;
            if (!CheckValidInput.CheckIfInputIsInRange(i_TypeOfFual, (1, enumListLength)))
            {
                throw new ValueOutOfRangeException(1, enumListLength, "You chose an invalid value!");
            }
            else
            {
                fualType = (eFualType)(i_TypeOfFual - 1);
            }
            
            return fualType;
        }

        private static float GetAmountOfEnergyFromUser()
        {
            string amountOfEnergy;
            do
            {
                amountOfEnergy = Console.ReadLine();
            }
            while (!CheckValidInput.IsFloat(amountOfEnergy));

            return float.Parse(amountOfEnergy);
        }

        public static void SetCurrentAmountOfEnergyInEngine(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            string strAmountOfEnergy;
            Console.WriteLine(Messeges.ChooseCurrentAmountOfEnergy(i_GarageManeger, i_LicenseNumber));
            do
            {
                strAmountOfEnergy = Console.ReadLine();
            }
            while (!CheckValidInput.IsFloat(strAmountOfEnergy));
            float currentAmountOfEnergy = float.Parse(strAmountOfEnergy);
            i_GarageManeger.EnterVehicleCurrentEnergyStatus(i_LicenseNumber, currentAmountOfEnergy);

        }

        private static void SetEnergyPrecentageForVehicle(GarageManeger i_GarageManeger, string i_LicenseNumber)
        {
            Vehicle vehicle = i_GarageManeger.M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle;
            vehicle.M_PowerSourcePercentage = vehicle.M_Engine.M_AmountOfEnergyLeftInTheEngine / vehicle.M_Engine.M_AmountOfMaxEnergy;
        }
    }
}

