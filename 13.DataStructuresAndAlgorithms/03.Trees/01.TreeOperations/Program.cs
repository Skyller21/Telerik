using System;

namespace _01.TreeOperations
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // I have added some more children to see if it is workung correctly.
            var reader = new StringReader(@"10
                                            2 4
                                            3 2
                                            5 0
                                            3 5
                                            5 6
                                            5 1
                                            0 7
                                            7 8
                                            8 9");


            Console.SetIn(reader);

            int n = int.Parse(Console.ReadLine().Trim());

            var nodes = new List<TreeNode<int>>();

            GenerateTree(n, nodes);

            var root = FindRoot(nodes);

            Console.WriteLine("Root is: {0}", root.Value);

            var leafs = FindLeafs(nodes);
            Console.WriteLine("\nLeafs are: {0}", string.Join(", ", leafs.Select(p => p.Value)));

            var middleNodes = FindMiddleNodes(nodes);
            Console.WriteLine("\nMiddle nodes are: {0}", string.Join(", ", middleNodes.Select(p => p.Value)));

            var longestPath = FindLongestPath(root, nodes);
            Console.WriteLine("\nLongest path is: {0}", longestPath);

            Console.WriteLine("\nThe tree\n=============");
            PrintTree(root);


            // *Paths with sum
            var list = new List<int>();
            int sumToFind = 14;
            Console.WriteLine("\nPaths with sum {0}\n=============", sumToFind);
            FindsPathWithSum(root, list, sumToFind);
            

            var sumToFindInSubTree = 6;
            Console.WriteLine("\nSubtrees with sum: {0}\n=============", sumToFindInSubTree);
            var listOfTrees = new LinkedList<LinkedList<int>>();
            FindSubtrees(root, listOfTrees);

            foreach (var subTree in listOfTrees)
            {
                if (subTree.Sum() == sumToFindInSubTree)
                {
                    Console.WriteLine(string.Join(", ", subTree));
                }
            }
        }

        private static int FindLongestPath(TreeNode<int> root, List<TreeNode<int>> nodes)
        {
            var longestPath = 1;
            var queue = new Queue<TreeNode<int>>();
            queue.Enqueue(root);
            root.Level = 0;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Children.Any())
                {
                    foreach (var treeNode in node.Children)
                    {
                        treeNode.Level = node.Level + 1;
                        queue.Enqueue(treeNode);
                    }
                }
            }

            longestPath += nodes.Max(p => p.Level.Value);
            return longestPath;
        }

        private static List<TreeNode<int>> FindMiddleNodes(List<TreeNode<int>> nodes)
        {
            return nodes.Where(p => p.Children.Any() && p.Parent != null).ToList();
        }

        private static List<TreeNode<int>> FindLeafs(List<TreeNode<int>> nodes)
        {
            return nodes.Where(p => p.Children.Count == 0).ToList();
        }

        private static TreeNode<int> FindRoot(List<TreeNode<int>> nodes)
        {
            return nodes.FirstOrDefault(p => p.Parent == null);
        }

        private static void GenerateTree(int n, List<TreeNode<int>> nodes)
        {
            for (int i = 0; i < n; i++)
            {
                nodes.Add(new TreeNode<int>(i));
            }

            for (int i = 0; i < n - 1; i++)
            {
                var pair =
                    Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();

                var parentValue = pair[0];

                var childValue = pair[1];

                nodes[childValue].Parent = nodes[parentValue];

                nodes[parentValue].Children.Add(nodes[childValue]);
            }
        }

        private static void PrintTree(TreeNode<int> node)
        {
            Console.WriteLine(node.Value.ToString().PadLeft(node.Level.Value * 2 + 1, ' '));
            foreach (var child in node.Children)
            {
                PrintTree(child);
            }
        }


        private static void FindsPathWithSum(TreeNode<int> node, List<int> list, int sum)
        {
            list.Add(node.Value);

            foreach (var child in node.Children)
            {
                FindsPathWithSum(child, list, sum);
            }

            if (!node.Children.Any())
            {
                if (list.Sum() == sum)
                {
                    Console.WriteLine(string.Join(", ", list));
                }
            }
            list.Remove(node.Value);
        }

        // It is implemented with list of lists so it can keep track of the nodes :)
        private static void FindSubtrees(TreeNode<int> node, LinkedList<LinkedList<int>> list)
        {
            foreach (var child in node.Children)
            {
                if (child.Children.Any())
                {
                    var newList = new LinkedList<int>();
                    list.AddFirst(newList);
                }

                FindSubtrees(child, list);
                list.First.Value.AddFirst(child.Value);
            }
        }
    }
}
