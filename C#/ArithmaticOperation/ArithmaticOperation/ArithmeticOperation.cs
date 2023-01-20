using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmaticOperation
{
    internal class ArithmeticOperation
    {
        public double Addition(double firstvalue,double secondvalue)
        {
            return firstvalue + secondvalue;
        }

        public double Subtraction(double firstvalue, double secondvalue)
        {
            return firstvalue - secondvalue;
        }

        public double Multiplication(double firstvalue, double secondvalue)
        {
            return firstvalue * secondvalue;
        }

        public double Division(double firstvalue, double secondvalue)
        {
            return firstvalue / secondvalue;
        }

        public double MaxValue(double firstvalue, double secondvalue)
        {
            double max=0;
            if(firstvalue<secondvalue)
            {
                max=secondvalue;
            }
            else
            {
                max=firstvalue;
            }
            return max;
        }
    }
}
