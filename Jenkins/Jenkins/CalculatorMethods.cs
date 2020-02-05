using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins
{
    public class CalculatorMethods
    {
        public double Accumulator { get; private set; }

        public void Clear()
        {
            Accumulator = 0;
        }
        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;
            return a * b;
        }

        public double Divide(double dividend, double divisor)
        {
            if (divisor != 0)
            {
                Accumulator = dividend / divisor;
                return dividend / divisor;
            }
            else
            {
                Accumulator = 0.0;
                return 0.0;
            }
        }

        public double Power(double x, int exp)
        {
            Accumulator = Math.Pow(x, exp);
            return Math.Pow(x, exp);
        }

        public double AddToAccumulator(double a)
        {
            Accumulator = Accumulator + a;
            return Accumulator;
        }

        public double SubtractFromAccumulator(double a)
        {
            Accumulator = Accumulator - a;
            return Accumulator;
        }

        public double MultiplyWithAccumulator(double a)
        {
            Accumulator = Accumulator * a;
            return Accumulator;
        }

        public double DivideAccumulatorWith(double a)
        {
            if (a != 0)
            {
                Accumulator = Accumulator / a;
                return Accumulator;
            }
            else
            {
                Accumulator = Accumulator;
                return Accumulator;
            }
        }

        public double PowerToAccumulator(int exp)
        {
            Accumulator = Math.Pow(Accumulator, exp);
            return Accumulator;
        }
    }
}
