using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected string? m_ManufacturerName = null;
        protected float? m_CurrentAirPressurePSI = null;
        protected float m_MaxAirPressurePSI;

        public Wheel(float i_MaxAirPressurePSI)
        {
            this.m_MaxAirPressurePSI = i_MaxAirPressurePSI;
        }

        public void InflateWheel(float i_AmountOfPressureToAdd)
        {
            if (this.M_CurrentAirPressurePSI + i_AmountOfPressureToAdd > this.M_MaxAirPressurePSI)
            {
                throw new ValueOutOfRangeException(0, M_MaxAirPressurePSI, "Air pressure exceeded the max allowed pressure!");
            }
            else
            {
                this.M_CurrentAirPressurePSI = this.M_CurrentAirPressurePSI + i_AmountOfPressureToAdd;
            }
        }

        public void InflateWheelToMax()
        {
            this.m_CurrentAirPressurePSI = this.m_MaxAirPressurePSI;
        } 

        public string? M_ManufacturerName
        {
            get 
            { 
                return this.m_ManufacturerName; 
            }
            set 
            { 
                this.m_ManufacturerName = value; 
            }
        }

        public float? M_CurrentAirPressurePSI
        {
            get
            {
                return this.m_CurrentAirPressurePSI;
            }
            set
            {
                this.m_CurrentAirPressurePSI = value;
            }
        }

        public float M_MaxAirPressurePSI
        {
            get
            {
                return this.m_MaxAirPressurePSI;
            }
        }
    }
}
