using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const int v_NumOfWheels = 16;
        private const float v_MaxTruckWheelPressureInPSI = 25f;
        private const float v_MaxFualCapacity = 153f;
        private const eFualType v_FualType = eFualType.Soler;
        protected bool m_DoesTruckContainColdLoad;
        protected float m_MaxLoadWeight;

        public Truck(string i_model, string i_licenseNumber) : base(i_model, i_licenseNumber)
        {
            this.M_WheelsList = buildWheelsListForTruck();
            this.M_Engine = new FualEngine(v_MaxFualCapacity, v_FualType);

        }

        protected static List<Wheel> buildWheelsListForTruck()
        {
            List<Wheel> listOfWheels = new List<Wheel>();
            for (int i = 0; i < v_NumOfWheels; i++)
            {
                listOfWheels.Add(new Wheel(v_MaxTruckWheelPressureInPSI));
            }
            return listOfWheels;
        }

        public bool M_DoesTruckContainColdLoad
        {
            get 
            { 
                return this.m_DoesTruckContainColdLoad; 
            }
            set
            {
                this.m_DoesTruckContainColdLoad = value;
            }
        }

        public float M_MaxLoadWeight
        {
            get
            {
                return this.m_MaxLoadWeight;
            }
            set 
            { 
                this.m_MaxLoadWeight = value; 
            }
        }

        public override void InflateWheelsToMax()
        {
            foreach (Wheel wheel in M_WheelsList)
            {
                wheel.InflateWheelToMax();
            }
        }
    }
}
