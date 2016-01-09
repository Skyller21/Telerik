namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class UnitsOfWork
    {
        private static Dictionary<string, SortedSet<Unit>> unitByType;
        private static Dictionary<string, Unit> units;
        private static SortedSet<Unit> unitByAttack;


        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            unitByType = new Dictionary<string, SortedSet<Unit>>();
            unitByAttack = new SortedSet<Unit>();
            units = new Dictionary<string, Unit>();

            while (line != "end")
            {
                var data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = data[0];

                if (command == "add")
                {
                    Add(data);
                }
                else if (command == "remove")
                {
                    Remove(data);
                }

                else if (command == "find")
                {
                    IEnumerable<Unit> filtered = FilterByType(data[1]);
                    if (filtered != null)
                    {
                        Console.WriteLine("RESULT: {0}", string.Join(", ", filtered));
                    }
                    else
                    {
                        Console.WriteLine("RESULT: ");

                    }
                }

                else if (command == "power")
                {
                    Console.WriteLine("RESULT: {0}", string.Join(", ", unitByAttack.Take(int.Parse(data[1]))));

                }

                line = Console.ReadLine();
            }
        }

        private static IEnumerable<Unit> FilterByPower(int number)
        {
            return null;

        }

        private static IEnumerable<Unit> FilterByType(string type)
        {
            if (unitByType.ContainsKey(type))
            {
                return unitByType[type].Take(10);
            }

            return null;
        }

        private static void Add(string[] data)
        {
            var name = data[1];
            var type = data[2];
            var attack = int.Parse(data[3]);
            var unit = new Unit(name, type, attack);

            if (!units.ContainsKey(name))
            {
                units.Add(name, unit);
            }

            if (!unitByAttack.Contains(unit))
            {
                unitByAttack.Add(unit);
            }

            if (!unitByType.ContainsKey(type))
            {
                unitByType.Add(type, new SortedSet<Unit>());
            }

            if (unitByType[type].All(p => p.Name != unit.Name))
            {


                unitByType[type].Add(unit);

                Console.WriteLine("SUCCESS: {0} added!", unit.Name);
            }
            else
            {
                Console.WriteLine("FAIL: {0} already exists!", unit.Name);

            }
        }

        private static void Remove(string[] data)
        {
            var name = data[1];
            if (units.ContainsKey(name))
            {
                var unitToDelete = units[name];

                var deleted = units.Remove(name);




                unitByType[unitToDelete.Type].Remove(unitToDelete);
                unitByAttack.Remove(unitToDelete);

                Console.WriteLine("SUCCESS: {0} removed!", unitToDelete.Name);

            }

            else
            {
                Console.WriteLine("FAIL: {0} could not be found!", name);

            }
        }



    }

    class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int CompareTo(Unit other)
        {
            if (other.Attack.CompareTo(this.Attack) == 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return other.Attack.CompareTo(this.Attack);
        }


        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }
}
