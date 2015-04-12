using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    class Iron:Item
    {
        private const int GeneralIronValue = 3;

        public Iron(string name, Location location = null)
            : base(name,Iron.GeneralIronValue, ItemType.Iron, location)
        {
        }

        static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Weapon };
        }
    }
}
