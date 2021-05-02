using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    /// <summary>
    /// BinaryNode holds an operation such as add/sub/mult/div
    /// and two leaf nodes. It can evalute the it's expression.
    /// </summary>
    public class BinaryNode : Node
    {

        private readonly Func<int, int, int> _operation;

        public BinaryNode(Func<int, int, int> operation)
        {
            this._operation = operation;
        }

        public BinaryNode(Func<int, int, int> operation, Node leftNode, Node rightNode)
        {
            this._operation = operation;
            this.LeftNode = leftNode;
            this.RightNode = rightNode;
        }

        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }

        /// <summary>
        /// Evalute value of the leaf nodes using a supported opeation (add/sub/mult/div)
        /// </summary>
        /// <returns>An integer</returns>
        public override int Eval()
        {
            return _operation.Invoke(this.LeftNode.Eval(), this.RightNode.Eval());
        }
    }
}
