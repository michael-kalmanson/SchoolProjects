using Ex03.GarageLogic;
   

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            Run();
        }
       
        public static void Run()
        {
            GarageManeger garageManeger = new GarageManeger();
            int userInput;

            do
            {
                Console.WriteLine(Messeges.WelcomeMsg());
                userInput = GetInputFromUser(garageManeger);

                try
                {
                    switch (userInput)
                    {
                        case 1:
                            {
                                GarageMethods.InsertNewVehicle(garageManeger);
                                break;
                            }
                        case 2:
                            {
                                GarageMethods.ShowListOfVehicle(garageManeger);
                                break;
                            }
                        case 3:
                            {
                                GarageMethods.ChangeStatusOfVehicle(garageManeger);
                                break;
                            }
                        case 4:
                            {
                                GarageMethods.InflateWheelsToMax(garageManeger);
                                break;
                            }
                        case 5:
                            {
                                GarageMethods.FualingFualVehicle(garageManeger);
                                break;
                            }
                        case 6:
                            {
                                GarageMethods.CharginElectricVehicle(garageManeger);
                                break;
                            }
                        case 7:
                            {
                                GarageMethods.ShowInfoOnVehicle(garageManeger);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Please press enter to continue actions");
                Console.ReadLine();
                Console.Clear();
            }
            while (userInput != 8);
            Console.WriteLine("End of using the Garage");
            Thread.Sleep(2500);
        }

        public static int GetInputFromUser(GarageManeger i_GarageManeger)
        {
            string strNumOfAction = Console.ReadLine();
            while (!CheckValidInput.inputForChoosingAction(strNumOfAction))
            {
                strNumOfAction = Console.ReadLine();
            }

            return int.Parse(strNumOfAction);
        }
    }
}
