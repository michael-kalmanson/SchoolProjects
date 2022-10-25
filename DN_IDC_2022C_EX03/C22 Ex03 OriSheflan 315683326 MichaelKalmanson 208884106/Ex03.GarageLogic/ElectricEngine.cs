using System;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxFualCapacity) : base(i_MaxFualCapacity)
        {
            
        }

        internal void ChargeEngine(float i_AmountOfEnergyToFill)
        {
            if (this.M_AmountOfMaxEnergy > this.M_AmountOfEnergyLeftInTheEngine + i_AmountOfEnergyToFill)
            {
                throw new ValueOutOfRangeException(0, M_AmountOfMaxEnergy,
                    "Amount of charging time you entered plus current battery of engine exceeded the maximum allowed in the vehicle.");
            }
            else
            {
                this.M_AmountOfEnergyLeftInTheEngine = this.M_AmountOfEnergyLeftInTheEngine + i_AmountOfEnergyToFill;
            }
        }
    }
}
