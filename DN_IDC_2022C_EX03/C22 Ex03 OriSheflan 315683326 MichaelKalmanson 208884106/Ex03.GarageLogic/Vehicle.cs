using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string? m_Model = null;
        protected string? m_LicenseNumber = null;
        protected float m_PowerSourcePercentage;
        protected List<Wheel>? m_WheelsList = null;
        protected Engine? m_Engine = null;

        public Vehicle(string i_model, string i_licenseNumber)
        {
            this.m_Model = i_model;
            this.m_LicenseNumber = i_licenseNumber;
        }

        public string? M_Model
        {
            get
            {
                return this.m_Model;

            }
            set
            {
                this.m_Model = value;
            }
        }

        public string? M_LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;

            }
            set
            {
                this.m_LicenseNumber = value;
            }
        }
        
        public float M_PowerSourcePercentage
        {
            get
            {
                return this.m_PowerSourcePercentage;

            }
            set
            {
                this.m_PowerSourcePercentage = value;
            }
        }
        
        public List<Wheel>? M_WheelsList
        {
            get
            {
                return this.m_WheelsList;

            }
            set
            {
                this.m_WheelsList = value;
            }
        }

        public Engine M_Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }

        public abstract void InflateWheelsToMax();
    }
}