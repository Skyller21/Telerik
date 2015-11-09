namespace Hash.Tests
{
    using _04.HashTableImplementation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void ShouldCreateObjectInstanceWithRightDefaultParameters()
        {
            var table = new HashTable<int, int>();
            Assert.AreEqual(0, table.Count);
        }

        [TestMethod]

        public void ShouldAddCorrectNumberOfElements()
        {
            var table = new HashTable<int, int>();
            table.Add(1, 1);
            table.Add(2, 2);
            table.Add(3, 3);
            Assert.AreEqual(3, table.Count);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueByKey()
        {
            var table = new HashTable<int, int>();
            table.Add(1, 111);
            var found = table.Find(1);

            Assert.AreEqual(found, 111);
        }

        [TestMethod]
        public void ShouldReturnDefaultValueWhenKeyNotFound()
        {
            var table = new HashTable<int, int>();
            table.Add(1, 111);
            var found = table.Find(8);

            Assert.AreEqual(found, 0);
        }

        [TestMethod]
        public void ShouldReturnDefaultValueWhenKeyAndValueIsString()
        {
            var table = new HashTable<int, string>();
            table.Add(1, "111");
            var found = table.Find(8);

            Assert.IsNull(found);
        }

        [TestMethod]
        public void ShouldAutoResizeInnerCollection()
        {
            var table = new HashTable<int, int>();
            table.Add(1, 111);
            table.Add(2, 211);
            table.Add(3, 131);

            Assert.AreEqual(3, table.Count);
        }

        [TestMethod]
        public void ShouldReturnKeysCorrectly()
        {
            var table = new HashTable<int, int>();
            var keys = new List<int>() { 1, 2, 3 };

            foreach (int key in keys)
            {
                table.Add(key, key * 100);
            }

            CollectionAssert.AreEqual(keys, table.Keys.ToList());
        }


        [TestMethod]
        public void ShouldIterateCorrectly()
        {
            var result = new List<KeyValuePair<int, int>>();
            var keys = new[] { 1, 3, 5, 7, 9 };
            var values = new[] { 10, 30, 50, 70, 90 };

            var table = new HashTable<int, int>();
            foreach (var key in keys)
            {
                table.Add(key, key * 10);
            }

            foreach (var pair in table)
            {
                result.Add(pair);
            }

            var finalKeys = result.Select(x => x.Key).ToArray();
            var finalValues = result.Select(x => x.Value).ToArray();
            CollectionAssert.AreEqual(keys, finalKeys);
            CollectionAssert.AreEqual(values, finalValues);
        }
    }
}