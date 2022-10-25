namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float v_MaxElectricEngineCapacity = 2.8f;
        public ElectricMotorcycle(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber)
        {
            this.M_Engine = new ElectricEngine(v_MaxElectricEngineCapacity);
        }
    }
}
