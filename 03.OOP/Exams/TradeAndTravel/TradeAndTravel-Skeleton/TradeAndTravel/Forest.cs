using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    class Forest:GatheringLocation
    {
        public Forest(string name)
            : base(name, LocationType.Forest,ItemType.Iron, ItemType.Armor)
        {
        }

        public override Item ProduceItem(string name)
        {
            return new Iron(name, null);
        }
    }
}
