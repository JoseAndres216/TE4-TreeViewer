using System;
using System.Collections.Generic;
using System.Text;

namespace TreeViewer.DataStructures.BinaryTree
{
    public class BinaryTree
    {
        public BTNode Root { get; set; }
        public List<int> PREOrderList = new List<int>();
        public List<int> INOrderList = new List<int>();
        public List<int> POSTOrderList = new List<int>();

        public bool Add(int value)
        {
            BTNode before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.LeftNode;
                else if (value > after.Data)
                    after = after.RightNode;
                else
                {
                    return false;
                }
            }

            BTNode newNode = new BTNode();
            newNode.Data = value;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        private BTNode Remove(BTNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Data)
                parent.RightNode = Remove(parent.RightNode, key);

            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Data = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        private int MinValue(BTNode node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }


        public void PREOrder(BTNode parent)
        {
            if (parent != null)
            {
                PREOrderList.Add(parent.Data);
                PREOrder(parent.LeftNode);
                PREOrder(parent.RightNode);
            }
        }

        public void INOrder(BTNode parent)
        {
            if (parent != null)
            {
                INOrder(parent.LeftNode);
                INOrderList.Add(parent.Data);
                INOrder(parent.RightNode);
            }
        }

        public void POSTOrder(BTNode parent)
        {
            if (parent != null)
            {
                POSTOrder(parent.LeftNode);
                POSTOrder(parent.RightNode);
                POSTOrderList.Add(parent.Data);
            }
        }
    }
}
