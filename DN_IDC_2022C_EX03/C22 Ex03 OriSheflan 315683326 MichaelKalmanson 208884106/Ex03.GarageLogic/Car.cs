using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle 
    {
        protected const int v_NumOfWheels = 4;
        protected const float v_MaxCarWheelPressureInPSI = 27f;
        protected eCarColor m_CarColor;
        protected eNumOfDoors m_NumOfDoors;

        public Car(string i_model, string i_licenseNumber): base(i_model, i_licenseNumber)
        {
            this.M_WheelsList = buildWheelsListForCar();
        }

        protected static List<Wheel> buildWheelsListForCar()
        {
            List <Wheel> listOfWheels = new List<Wheel>();
            for (int i = 0; i < v_NumOfWheels; i++)
            {
                listOfWheels.Add(new Wheel(v_MaxCarWheelPressureInPSI));
            }
            return listOfWheels;
        }

        public eCarColor M_CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                this.m_CarColor = value;
            }
        }

        public eNumOfDoors M_NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                this.m_NumOfDoors = value;
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