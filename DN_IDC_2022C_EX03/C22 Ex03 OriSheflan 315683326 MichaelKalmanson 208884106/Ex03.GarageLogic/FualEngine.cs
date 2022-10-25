using System;

namespace Ex03.GarageLogic
{
    internal class FualEngine : Engine
    {
        private readonly eFualType r_FualType;

        public FualEngine(float i_MaxFualCapacity, eFualType i_FualType): base(i_MaxFualCapacity)
        {
            this.r_FualType = i_FualType;
        }

        internal void FillEngineWithFual(float i_AmountOfEnergyToFill, eFualType i_FualType)
        {
            if (this.M_AmountOfMaxEnergy < this.M_AmountOfEnergyLeftInTheEngine + i_AmountOfEnergyToFill)
            {
                throw new ValueOutOfRangeException(0, M_AmountOfMaxEnergy, "Amount of fual you entered plus current fual in the tank exceeded the maximum allowed in the vehicle.");
            }
            else if (i_FualType != r_FualType)
            {
                throw new ArgumentException("You entered an incompatable fual type!");
            }
            else
            {
                this.M_AmountOfEnergyLeftInTheEngine = this.M_AmountOfEnergyLeftInTheEngine + i_AmountOfEnergyToFill;
            }
        }

        public eFualType M_FualType
        {
            get 
            { 
                return r_FualType; 
            }
        }
    }

}

