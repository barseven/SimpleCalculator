using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    public class Operators
    {
        private static Func<int, int, int> add = (a, b) => a + b;
        private static Func<int, int, int> sub = (a, b) => a - b;
        private static Func<int, int, int> mult = (a, b) => a * b;
        private static Func <int, int, int> div = (a, b) => a / b;

        public static Func<int, int, int> Add
        {
            get
            {
                return add;
            }
        }

        public static Func<int, int, int> Sub
        {
            get
            {
                return sub;
            }
        }

        public static Func<int, int, int> Mult
        {
            get
            {
                return mult;
            }
        }

        public static Func<int, int, int> Div
        {
            get
            {
                return div;
            }
        }


    }
}
