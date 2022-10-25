using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class GarageManeger
    {
        // $G$ DSN-999 (-3) This Dictionary should be readonly.
        private Dictionary<string, GarageNote> m_GarageVehcleDictionary;

        public GarageManeger()
        {
            m_GarageVehcleDictionary = new Dictionary<string, GarageNote>();
        }

        public void AddNewVehicle(string i_NameOfVehicleOwner, string i_PhoneNumberOfVehicleOwner, eVehicleType i_VehicleType, string i_Model, string i_LicenseNumber)
        {
            GarageNote vehicleGarageNote = new GarageNote(i_NameOfVehicleOwner, i_PhoneNumberOfVehicleOwner, i_VehicleType, i_Model, i_LicenseNumber);
            this.addNewVehicle(i_LicenseNumber, vehicleGarageNote);
        }

        private void addNewVehicle(string i_LicenseNumber, GarageNote i_VehicleGarageNote)
        {
            m_GarageVehcleDictionary.Add(i_LicenseNumber, i_VehicleGarageNote);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            bool isVehicleInGarage = false;
            if (m_GarageVehcleDictionary.ContainsKey(i_LicenseNumber))
            {
                isVehicleInGarage = true;
            }

            return isVehicleInGarage;
        }

        public Dictionary<string, eStatusOfVehicle> ShowVehiclesInTheGarageByCurrentStatus(eStatusOfVehicle i_StateOfVehicle)
        {
            Dictionary<string, eStatusOfVehicle> sortedDictionaryToReturn = new Dictionary<string, eStatusOfVehicle>();
            foreach (var keyAndValue in m_GarageVehcleDictionary)
            {
                if (keyAndValue.Value.M_StateOfVehicle == i_StateOfVehicle)
                {
                    sortedDictionaryToReturn.Add(keyAndValue.Key, keyAndValue.Value.M_StateOfVehicle);
                }
            }

            return sortedDictionaryToReturn;
        }

        public Dictionary<string, eStatusOfVehicle> ShowVehiclesInTheGarageByCurrentStatus()
        {
            Dictionary<string, eStatusOfVehicle> sortedDictionaryToReturn = new Dictionary<string, eStatusOfVehicle>();
            foreach (var keyAndValue in m_GarageVehcleDictionary)
            {
                sortedDictionaryToReturn.Add(keyAndValue.Key, keyAndValue.Value.M_StateOfVehicle);
            }

            return sortedDictionaryToReturn;

        }

        public void ChangeCarStatus(string i_LicenseNumber, eStatusOfVehicle i_StatusOfVehicle)
        {
            m_GarageVehcleDictionary[i_LicenseNumber].M_StateOfVehicle = i_StatusOfVehicle;
        }

        public void InflateWheelsToMax(string i_LicenseNumber)
        {
            m_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.InflateWheelsToMax();
        }

        public void FillFualInVehicle(string i_LicenseNumber, eFualType i_FualType, float i_AmountOfFualToFill)
        {
            FualEngine EngineToFill = m_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.M_Engine as FualEngine;
            EngineToFill.FillEngineWithFual(i_AmountOfFualToFill, i_FualType);
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_NumberOfMinutesToCharge)
        {
            ElectricEngine EngineToCharge = m_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.M_Engine as ElectricEngine;
            EngineToCharge.ChargeEngine(i_NumberOfMinutesToCharge);
        }

        public GarageNote FetchVehicleData(string i_LicenceNumber)
        {
            return m_GarageVehcleDictionary[i_LicenceNumber];
        }

        public Dictionary<string, GarageNote> M_GarageVehcleDictionary
        {
            get 
            {
                return this.m_GarageVehcleDictionary;
            }
            set
            {
                this.m_GarageVehcleDictionary = value;
            }
        }

        public List<MethodInfo> BuildMethodsForSpecificVehicle(Vehicle i_Vehicle, string i_MethodNameToLookFor)
        {
            List<MethodInfo> listOfUniqueMethods = new List<MethodInfo>();
            MethodInfo[] allOfSpecialVehicleMethods = i_Vehicle.GetType().GetMethods();
            MethodInfo[] allOfVehicleMethods = typeof(Vehicle).GetMethods();
            List < MethodInfo > listOfAllOfVehicleMethods = new List<MethodInfo>(allOfVehicleMethods);

            foreach (MethodInfo vehicleMethod in allOfSpecialVehicleMethods)
            {
                if (vehicleMethod.Name.Contains(i_MethodNameToLookFor))
                {
                    listOfUniqueMethods.Add(vehicleMethod);
                }
            }

            return listOfUniqueMethods;
        }

        public bool IsFualEngine(string i_licenseNumber)
        {
            return (M_GarageVehcleDictionary[i_licenseNumber].M_Vehicle.M_Engine.GetType() == typeof(FualEngine));
        }

        public void EnterVehicleCurrentEnergyStatus(string i_LicenseNumber, float i_EnergyStatus)
        {
            float vehicleMaxEnergy = M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.M_Engine.M_AmountOfMaxEnergy;
            if (i_EnergyStatus > vehicleMaxEnergy || i_EnergyStatus < 0)
            {
                throw new ValueOutOfRangeException(0, vehicleMaxEnergy, "The entered energy status is not in the allowed range");
            }
            else
            {
                M_GarageVehcleDictionary[i_LicenseNumber].M_Vehicle.M_Engine.M_AmountOfEnergyLeftInTheEngine = i_EnergyStatus;
            }
        }
    }
}
