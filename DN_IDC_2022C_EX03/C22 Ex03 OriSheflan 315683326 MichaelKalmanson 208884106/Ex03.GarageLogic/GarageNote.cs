namespace Ex03.GarageLogic
{
    public class GarageNote
    {
        private readonly string r_NameOfVehicleOwner;
        private readonly string r_PhoneNumberOfVehicleOwner;
        private eStatusOfVehicle m_StateOfVehicle;
        private Vehicle m_Vehicle;

        public GarageNote(string i_NameOfVehicleOwner, string i_PhoneNumberOfVehicleOwner, eVehicleType i_VehicleType, string i_Model, string i_LicenseNumber)
        {
            this.r_PhoneNumberOfVehicleOwner = i_PhoneNumberOfVehicleOwner;
            this.r_NameOfVehicleOwner = i_NameOfVehicleOwner;
            this.m_StateOfVehicle = eStatusOfVehicle.BeingRepaired;
            this.m_Vehicle = VehicleBuilder.BuildVehicle(i_VehicleType, i_Model, i_LicenseNumber);
        }

        public string M_NameOfCarOwner 
        {
            get
            {
                return r_NameOfVehicleOwner;
            }
        }

        public string M_PhoneNumberOfCarOwner
        {
            get
            {
                return r_PhoneNumberOfVehicleOwner;
            }
        }

        public eStatusOfVehicle M_StateOfVehicle 
        {
            get
            {
                return this.m_StateOfVehicle; 
            }
            set
            {
                this.m_StateOfVehicle = value;
            }
        }

        public Vehicle M_Vehicle
        {
            get
            {
                return this.m_Vehicle;
            }
            set
            {
                this.m_Vehicle = value;
            }
        }
    }
}
