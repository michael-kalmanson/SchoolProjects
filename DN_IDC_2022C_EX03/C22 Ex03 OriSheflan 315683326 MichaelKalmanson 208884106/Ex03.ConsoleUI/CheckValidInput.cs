using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class CheckValidInput
    {
        public static bool inputForChoosingAction(string i_Input)
        {

            bool isValid = true;
            if (i_Input != "1" && i_Input != "2" && i_Input != "3" && i_Input != "4" && i_Input != "5" && i_Input != "6" && i_Input != "7" 
                && i_Input != "8")
            {
                isValid = false;
                Console.WriteLine("Invalid input, you need to enter numnber between 1-8. please try again");
            }
            return isValid;
        }

        public static bool CheckNonEmptyInput(string i_Input)
        {
            bool isValid = true;
            if (i_Input == "")
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool LicenseNumberInput(string i_LicenseNumber)
        {
            bool isValid = true;
            if (i_LicenseNumber == "")
            {
                isValid = false;
                Console.WriteLine("Invalid input, you need to enter non-empty License number. please try again");

            }
            return isValid;
        }

        public static bool TypeOfVehicle(string i_TypeOfVehicle)
        {
         
         bool validTypeOfVehicle = false;

            foreach (int i in Enum.GetValues(typeof(eVehicleType))) 
            {
                
                if (i_TypeOfVehicle == (i+1).ToString())
                {
                    validTypeOfVehicle = true;
                }
            }
            return validTypeOfVehicle;
        }

        public static bool InputForWheelsInfo(string i_ManufacturerName, string i_StrCurrentAirPressurePSI, float? i_MaxAirPressurePSI)
        {
            bool ValidInput = true;

            if (!CheckNonEmptyInput(i_ManufacturerName) || !CheckNonEmptyInput(i_StrCurrentAirPressurePSI) || !(IsFloat(i_StrCurrentAirPressurePSI) && IsInt(i_StrCurrentAirPressurePSI)))
            {
                ValidInput = false;
                Console.WriteLine("Invalid input, please try again");
            }
            else if (float.Parse(i_StrCurrentAirPressurePSI) < 0 || float.Parse(i_StrCurrentAirPressurePSI) > i_MaxAirPressurePSI)
            {
                ValidInput = false;
                Console.WriteLine("Current air-pressure can not be greater than max air-pressure or smaller than 0");
            }

            return ValidInput;
        }

        public static bool IsInt(string i_Str)
        {
            int o_IntValue;
            bool isInt = true;
            if (!int.TryParse(i_Str, out o_IntValue))
            {
                throw new FormatException("Invalid input! must be a number!");
            }
            return isInt;
        }

        public static bool IsFloat(string i_Str)
        {
            float o_FloatValue;
            bool isFloat = true;
            if (!float.TryParse(i_Str, out o_FloatValue))
            {
                throw new FormatException("Invalid input! must be a number!");
            }
            return isFloat;
        }

        public static bool YesOrNoInput(string i_Str)
        {
            bool validInput = true;

            if (i_Str != "y" && i_Str != "n")
            {
                validInput = false;
                Console.WriteLine("InValid input, you input must be y/n. Please try again");
            }
            return validInput;
        }

        public static bool CheckIfInputIsInRange(float i_UserInput, (float, float) i_Range)
        {
            bool isInRange = true;
            if (i_UserInput > i_Range.Item2 || i_UserInput < i_Range.Item1)
            {
                string rangeErrorMessage = string.Format("You enter a number which is out of range ({0}, {1})", i_Range.Item1.ToString(), i_Range.Item2.ToString());
                Console.WriteLine(rangeErrorMessage);
                isInRange = false;
            }

            return isInRange;
        }

        public static bool InputForVehicleStatus(string i_NumberToCheck)
        {
            bool validInput = i_NumberToCheck == "1" || i_NumberToCheck == "2" || i_NumberToCheck == "3";
            if (!validInput)
            {
                Console.WriteLine("Invalid input! please press number between 1-3. Please try again");
            }
            return validInput;

            // $G$ CSS-027 (-2) Unnecessary blank lines.
        }

        public static bool InputForFualType(string i_NumberToCheck)
        {
            string[] enumListArray = Enum.GetNames(typeof(eFualType));
            int enumListLength = enumListArray.Length;
            bool validInput = false;
            for (int i = 1; i <= enumListLength; i++)
            {
                validInput = validInput || i_NumberToCheck.Equals(i.ToString());
            }
            if (!validInput)
            {
                Console.WriteLine(String.Format("Invalid input! please press number between 1-{0}. Please try again", enumListLength.ToString()));
            }

            return validInput;
        }
    }
}
