using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int MIN_HORSEPOWER = 70;
        private const int MAX_HORSEPOWER = 100;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 450)
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