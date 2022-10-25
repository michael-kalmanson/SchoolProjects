namespace Ex03.GarageLogic
{
    internal class FualMotorcycle : Motorcycle
    {
        private const float v_MaxFualEngineCapacity = 5.4f;
        private const eFualType v_FualType = eFualType.Octan98;
        public FualMotorcycle(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber)
        {
            this.M_Engine = new FualEngine(v_MaxFualEngineCapacity, v_FualType);
        }
    }
}
