namespace Ex03.GarageLogic
{
    internal class VehicleBuilder
    {
        public static Vehicle BuildVehicle(eVehicleType i_VehicleType, string i_Model, string i_LicenseNumber)
        {
            Vehicle vehicleToReturn = null;
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    {
                        vehicleToReturn = new ElectricCar(i_Model, i_LicenseNumber);
                        break;
                    }
                case eVehicleType.ElectricMotorcycle:
                    {
                        vehicleToReturn = new ElectricMotorcycle(i_Model, i_LicenseNumber);
                        break;
                    }
                case eVehicleType.FualCar:
                    {
                        vehicleToReturn = new FualCar(i_Model, i_LicenseNumber);
                        break;
                    }
                case eVehicleType.FualMotorcycle:
                    {
                        vehicleToReturn = new FualMotorcycle(i_Model, i_LicenseNumber);
                        break;
                    }
                case eVehicleType.Truck:
                    {
                        vehicleToReturn = new Truck(i_Model, i_LicenseNumber);
                        break;
                    }
            }
 
            return vehicleToReturn;
        }
    }
}
