namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_AmountOfEnergyLeftInTheEngine;
        protected float m_AmountOfMaxEnergy;

        public Engine(float i_AmountOfMaxEnergy)
        {
            this.m_AmountOfMaxEnergy = i_AmountOfMaxEnergy;
        }

        public float M_AmountOfEnergyLeftInTheEngine
        {
            get
            {
                return m_AmountOfEnergyLeftInTheEngine;
            }
            set
            {
                this.m_AmountOfEnergyLeftInTheEngine = value;
            }
        }

        public float M_AmountOfMaxEnergy
        {
            get
            {
                return m_AmountOfMaxEnergy;
            }
        }
    }
}
