using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MIN_HORSEPOWER = 50;
        private const int MAX_HORSEPOWER = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
        }

        public override int HorsePower
        {
            get => horsePower;

            protected set
            {
                if (value >= MIN_HORSEPOWER && value <= MAX_HORSEPOWER)
                {
                    horsePower = value;
                }

                else
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
            }
        }
    }
}