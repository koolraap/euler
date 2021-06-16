using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Extensions
{
    public class Node
    {
        public long Value;
        public Node Left;
        public Node Right;
        public long MaxPath;

        public Node()
        {
        }

        public Node(long value)
        {
            Value = value;
        }

        public T Walk<T>(Func<Node, T> doThingsFunc)
        {
            if (Left != null && Left.MaxPath == 0)
            {
                Left.Walk(doThingsFunc);
            }

            if (Right != null && Right.MaxPath == 0)
            {
                Right.Walk(doThingsFunc);
            }

            var x = doThingsFunc(this);

            return x;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public class NodeBuilder
    {
        public static Node Build(int[][] tree)
        {
            Node[][] nodes = new Node[tree.Length][];

            // for each row
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node[tree[i].Length];

                // for each item
                for (int j = 0; j < tree[i].Length; j++)
                {
                    nodes[i][j] = new Node(tree[i][j]);

                    // link parents to children
                    if (i > 0)
                    {
                        if (j < nodes[i].Length - 1)
                        {
                            nodes[i - 1][j].Left = nodes[i][j];
                        }
                        if (j > 0)
                        {
                            nodes[i - 1][j - 1].Right = nodes[i][j];
                        }
                    }
                }
            }

            return nodes[0][0];
        }
    }

}
