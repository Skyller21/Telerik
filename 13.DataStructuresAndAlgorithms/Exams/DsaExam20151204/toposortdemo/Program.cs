namespace TopoSortDemo
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    class Program
    {

        // Algorith from this site http://www.codeproject.com/Articles/869059/Topological-sorting-in-Csharp


        private static int n;
        private static int sum;
        private static int maxSum;
        private static List<Item2> unsorted;
        static void Main(string[] args)
        {
            unsorted = new List<Item2>();


            n = int.Parse(Console.ReadLine());

            var times = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int j = 0; j < times.Count(); j++)
            {
                var item = new Item2(j + 1, times[j]);
                unsorted.Add(item);
            }

            //var a = new Item2("1", 5);
            //var b = new Item2("2", 7, "1", "3");
            //var c = new Item2("3", 1);
            //var d = new Item2("4", 2, "2", "5");
            //var e = new Item2("5", 6, "1", "3");

            //unsorted = new List<Item2>() { a, b, c, d, e };



            sum = 0;
            maxSum = 0;

            try
            {

                for (int i = 0; i < n; i++)
                {
                    var data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    if (data.Count() == 1 && data[0] == 0)
                    {
                        unsorted[i].Dependencies = new List<int>();
                        continue;
                    }
                    else
                    {

                        unsorted[i].Dependencies = new List<int>();


                        foreach (var i1 in data)
                        {
                            unsorted[i1 - 1].DependenciesCount++;

                            unsorted[i].Dependencies.Add(i1);
                        }


                    }


                }


                var sorted = TopologicalSort.Group(unsorted, x => x.Dependencies, x => x.Name);


                var independant = sorted[0].Where(i => i.DependenciesCount == 0).ToList();
                var maxIndependantSum = 0;
                if (independant.Count > 0)
                {
                    maxIndependantSum = independant.Max(x => x.Value);
                }

                sorted[0] = sorted[0].Where(i => i.DependenciesCount != 0).ToList();

                sum = 0;



                for (int i = sorted[sorted.Count - 1].Count - 1; i >= 0; i--)
                {
                    sum = 0;
                    Sum(sorted[sorted.Count - 1].ToList()[i], sorted);
                }











                Console.WriteLine(Math.Max(maxSum, maxIndependantSum));
                //Print(sorted);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(-1);
            }





        }

        private static void Sum(Item2 i1, IList<ICollection<Item2>> sorted)
        {
            sum += i1.Value;
            if (i1.Dependencies.Count == 0)
            {
                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                return;
            }


            foreach (var dep in i1.Dependencies)
            {

                Sum(unsorted[dep - 1], sorted);

                sum -= unsorted[dep - 1].Value;
            }

            return;

        }


        static void Print<T>(IList<ICollection<T>> items)
        {
            foreach (var group in items)
            {
                foreach (var item in group)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
                Console.Write("/ ");
            }
            Console.WriteLine();
        }

    }

    public class GenericEqualityComparer<TItem, TKey> : EqualityComparer<TItem>
    {
        private readonly Func<TItem, TKey> getKey;
        private readonly EqualityComparer<TKey> keyComparer;

        public GenericEqualityComparer(Func<TItem, TKey> getKey)
        {
            this.getKey = getKey;
            keyComparer = EqualityComparer<TKey>.Default;
        }

        public override bool Equals(TItem x, TItem y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return keyComparer.Equals(getKey(x), getKey(y));
        }

        public override int GetHashCode(TItem obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return keyComparer.GetHashCode(getKey(obj));
        }
    }

    public class Item2
    {
        public int Name { get; private set; }
        public int Value { get; private set; }
        public List<int> Dependencies { get; set; }
        public int DependenciesCount { get; set; }

        public Item2(int name, int value, List<int> dependencies = null)
        {
            this.DependenciesCount = 0;
            this.Value = value;
            Name = name;
            Dependencies = dependencies;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }


    public static class TopologicalSort
    {
        private static Func<T, IEnumerable<T>> RemapDependencies<T, TKey>(IEnumerable<T> source, Func<T, IEnumerable<TKey>> getDependencies, Func<T, TKey> getKey)
        {
            var map = source.ToDictionary(getKey);
            return item =>
            {
                var dependencies = getDependencies(item);
                return dependencies != null
                    ? dependencies.Select(key => map[key])
                    : null;
            };
        }

        public static IList<T> Sort<T, TKey>(IEnumerable<T> source, Func<T, IEnumerable<TKey>> getDependencies, Func<T, TKey> getKey, bool ignoreCycles = false)
        {
            ICollection<T> source2 = (source as ICollection<T>) ?? source.ToArray();
            return Sort<T>(source2, RemapDependencies(source2, getDependencies, getKey), null, ignoreCycles);
        }

        public static IList<T> Sort<T, TKey>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies, Func<T, TKey> getKey, bool ignoreCycles = false)
        {
            return Sort<T>(source, getDependencies, new GenericEqualityComparer<T, TKey>(getKey), ignoreCycles);
        }

        public static IList<T> Sort<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies, IEqualityComparer<T> comparer = null, bool ignoreCycles = false)
        {
            var sorted = new List<T>();
            var visited = new Dictionary<T, bool>(comparer);

            foreach (var item in source)
            {
                Visit(item, getDependencies, sorted, visited, ignoreCycles);
            }

            return sorted;
        }

        public static void Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited, bool ignoreCycles)
        {
            bool inProcess;
            var alreadyVisited = visited.TryGetValue(item, out inProcess);

            if (alreadyVisited)
            {
                if (inProcess && !ignoreCycles)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
            else
            {
                visited[item] = true;

                var dependencies = getDependencies(item);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        Visit(dependency, getDependencies, sorted, visited, ignoreCycles);
                    }
                }

                visited[item] = false;
                sorted.Add(item);
            }
        }

        public static IList<ICollection<T>> Group<T, TKey>(IEnumerable<T> source, Func<T, IEnumerable<TKey>> getDependencies, Func<T, TKey> getKey, bool ignoreCycles = true)
        {
            ICollection<T> source2 = (source as ICollection<T>) ?? source.ToArray();
            return Group<T>(source2, RemapDependencies(source2, getDependencies, getKey), null, ignoreCycles);
        }

        public static IList<ICollection<T>> Group<T, TKey>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies, Func<T, TKey> getKey, bool ignoreCycles = true)
        {
            return Group<T>(source, getDependencies, new GenericEqualityComparer<T, TKey>(getKey), ignoreCycles);
        }

        public static IList<ICollection<T>> Group<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies, IEqualityComparer<T> comparer = null, bool ignoreCycles = true)
        {
            var sorted = new List<ICollection<T>>();
            var visited = new Dictionary<T, int>(comparer);

            foreach (var item in source)
            {
                Visit(item, getDependencies, sorted, visited, ignoreCycles);
            }

            return sorted;
        }

        public static int Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<ICollection<T>> sorted, Dictionary<T, int> visited, bool ignoreCycles)
        {
            const int inProcess = -1;
            int level;
            var alreadyVisited = visited.TryGetValue(item, out level);

            if (alreadyVisited)
            {
                if (level == inProcess && ignoreCycles)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
            else
            {
                visited[item] = (level = inProcess);

                var dependencies = getDependencies(item);
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        var depLevel = Visit(dependency, getDependencies, sorted, visited, ignoreCycles);
                        level = Math.Max(level, depLevel);
                    }
                }

                visited[item] = ++level;
                while (sorted.Count <= level)
                {
                    sorted.Add(new Collection<T>());
                }
                sorted[level].Add(item);
            }

            return level;
        }


    }

}
