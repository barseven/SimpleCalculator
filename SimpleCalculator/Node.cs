using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    /// <summary>
    /// Abstract class to provide an Eval method
    /// </summary>
    public abstract class Node
    {
        public abstract int Eval();
    }
}
