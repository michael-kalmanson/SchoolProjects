using System;

namespace Ex03.GarageLogic
{
    internal class FualCar : Car
    {
        private const float v_MaxFualTankCapacity = 52f;
        private const eFualType v_FualType = eFualType.Octan95;

        public FualCar(string i_Model, string i_LicenseNumber) : base(i_Model, i_LicenseNumber)
        {
            this.M_Engine = new FualEngine(v_MaxFualTankCapacity, v_FualType);
        }
    }
}

