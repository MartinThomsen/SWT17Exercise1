using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins
{
    class Program
    {
        static void Main(string[] args)
        {

            CalculatorMethods test = new CalculatorMethods();
            try
            {
                Console.WriteLine(test.Power(-2, 1.5));
                Console.WriteLine(test.PowerToAccumulator(1.5));
            }
            catch (PowerException)
            {
                Console.WriteLine("use none negative when using non integer power");

            }

        }
    }
}
