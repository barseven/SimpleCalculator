using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    /// <summary>
    /// ValueNode is a leaf node holding an integer value. It evaluates to it's own value.
    /// </summary>
    public class ValueNode : Node
    {
        private readonly int _value;

        public ValueNode(int value)
        {
            this._value = value;
        }

        /// <summary>
        /// ValueNode evaluates to the value it's holding
        /// </summary>
        /// <returns></returns>
        public override int Eval()
        {
            return _value;
        }
    }
}
