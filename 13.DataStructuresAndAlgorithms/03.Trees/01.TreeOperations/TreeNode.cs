using System;
using System.Collections.Generic;

namespace _01.TreeOperations
{
    public class TreeNode<T>
    {
        private T value;
        private TreeNode<T> parent;
        private IList<TreeNode<T>> children;
        private int? level;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public TreeNode<T> Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public IList<TreeNode<T>> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public int? Level
        {
            get { return level; }
            set { level = value; }
        }
    }
}
