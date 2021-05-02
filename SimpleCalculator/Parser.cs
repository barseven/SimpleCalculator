using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCalculator
{
    /// <summary>
    /// Parses an input string such as add(1,2)
    /// into a binary tree, where the root node
    /// can evaluate the expression tree.
    /// </summary>
    public class Parser
    {
        public static BinaryNode Parse(string input)
        {

            BinaryNode root = null;
            BinaryNode current = null;
            BinaryNode parent = null;

            // opStack holds the method/function (add/sub/div/mult)
            // while the input is being parsed
            Stack<string> opStack = new Stack<string>();

            // valueStack holds the integers while the
            // input is being parsed
            Stack<string> valueStack = new Stack<string>();

            // nodes holds the BinaryNodes, so when a 
            // parent node needs to be assigned, it somes
            // from here
            List<BinaryNode> nodes = new List<BinaryNode>();

            // keep track of the depth level in the tree
            int level = 0;
            int index = 0;

            foreach (char token in input.ToCharArray())
            {
                if (token == '(') // if we get here when parsing, the opStack should now have the method/function
                {
                    // get the method from opStack could be add/sub/mult/div at this time
                    string method = FromStack(opStack);

                    if (root == null)
                    {
                        root = new BinaryNode(GetMethod(method));
                        current = root;
                        parent = root;

                        nodes.Add(root);

                    }
                    else
                    {
                        // keep track of the parent node
                        parent = current;

                        current = new BinaryNode(GetMethod(method));

                        if (parent.LeftNode == null)
                        {

                            parent.LeftNode = current;

                        }
                        else
                        {

                            parent.RightNode = current;

                        }

                        nodes.Add(current);
                        level++;
                        index++;

                    }

                    // clear the opStack
                    opStack.Clear();
                }

                // at close parens, we can create a leaf node (ValueNode)
                // it also means we are done parsin an expression, 
                // the parser will continue at a diff depth/level
                if (token == ')')
                {

                    if (current.RightNode == null)
                    {
                        string value = FromStack(valueStack);

                        current.RightNode = new ValueNode(Int32.Parse(value));
                        valueStack.Clear();
                    }

                    // checking for level value here,
                    // at the end of an expression, there can be multiple left perens,
                    // they were causing an issue here
                    if (level > 0) 
                    {
                        level--;
                        current = nodes[level];
                    }

                }

                // if we get to a comma, we should know the value for the leaf node (ValueNode)
                if (token == ',') 
                {
                    if (current.LeftNode == null)
                    {
                        string value = FromStack(valueStack);
                        current.LeftNode = new ValueNode(ParseInteger(value));
                        valueStack.Clear();
                    }
                }

                // push numbers on the valueStack
                if (token >= 48 && token <= 57)
                {
                    valueStack.Push(token.ToString());
                }

                // push letters on the opStack
                // whether is a valid method/function,
                // it will checked later
                if (token >= 97 && token <= 122)
                {
                    opStack.Push(token.ToString());
                }
            }

            return root;

        }

        /// <summary>
        /// Reurns characters accumulated on the stack as a string
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private static string FromStack(Stack<string> stack)
        {
            
            string value = string.Empty;

            foreach (var element in stack)
            {
                value += element;
            }

            char[] array = value.ToCharArray();

            Array.Reverse(array);

            return new string(array);
        }

        /// <summary>
        /// Returns Func for function name.   
        /// </summary>
        /// <param name="function"></param>
        /// <returns>Func<int, int, int>Throws ArgumentOutOfRangeException when function is not supported.</returns>
        private static Func<int, int, int> GetMethod(string function)
        {
            Func<int, int, int> func = null;

            switch (function)
            {
                case "add":
                    func = Operators.Add;
                    break;
                case "sub":
                    func = Operators.Sub;
                    break;
                case "mult":
                    func = Operators.Mult;
                    break;
                case "div":
                    func = Operators.Div;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Expression {function} is not supported.");
            }

            return func;
        }
    

        private static int ParseInteger(string value)
        {
            int number;
            
            bool success = Int32.TryParse(value, out number);

            if (success)
            {
                return number;
            }
            else
            {
                throw new ArgumentException($"Failed to convert {value} to an integer.");
            }

        }
    }
}
