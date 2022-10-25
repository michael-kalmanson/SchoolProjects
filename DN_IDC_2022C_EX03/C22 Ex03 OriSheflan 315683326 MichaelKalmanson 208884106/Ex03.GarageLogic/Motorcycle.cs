using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Motorcycle : Vehicle
    {
        private const int v_NumOfWheels = 2;
        private const float v_MaxMotorcycleWheelPressureInPSI = 31f;
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;

        public Motorcycle(string i_model, string i_licenseNumber): base(i_model, i_licenseNumber)
        {
            this.M_WheelsList = buildWheelsListForMotorcycle();
        }

        protected static List<Wheel> buildWheelsListForMotorcycle()
        {
            List<Wheel> listOfWheels = new List<Wheel>();
            for (int i = 0; i < v_NumOfWheels; i++)
            {
                listOfWheels.Add(new Wheel(v_MaxMotorcycleWheelPressureInPSI));
            }
            return listOfWheels;
        }

        public eLicenseType M_LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                this.m_LicenseType = value;
            }
        }

        public override void InflateWheelsToMax()
        {
            foreach (Wheel wheel in M_WheelsList)
            {
                wheel.InflateWheelToMax();
            }
        }

        public int M_EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                this.m_EngineVolume = value;
            }
        }
    }
}
