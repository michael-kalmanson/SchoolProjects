namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const float v_MaxElectricEngineCapacity = 4.5f;
        public ElectricCar(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber)
        {
             this.M_Engine = new ElectricEngine(v_MaxElectricEngineCapacity);
        }
    }
}
