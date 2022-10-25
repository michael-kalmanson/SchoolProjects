using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;
        public float MaxValue
        {
            get
            {
                return r_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return r_MinValue; 
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ErrorMessage) :
            base(string.Format("Value is not in range: [{0}, {1}]",i_MinValue, i_MaxValue))
        {

        }
    }
}