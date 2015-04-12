using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class AdvancedInteractionManager : InteractionManager
    {
        public AdvancedInteractionManager()
        {

        }
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
            return location;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;

                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
            return person;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    this.HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;

                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleCraftInteraction(Person actor, string craftedItemType, string craftedItemName)
        {
            var actorInventory = actor.ListInventory();
            switch (craftedItemType)
            {

                case "armor":

                    if (actorInventory.Any(x => x.ItemType == ItemType.Iron))
                    {
                        this.AddToPerson(actor, new Armor(craftedItemName));

                    }
                    break;
                case "weapon":

                    if (actorInventory.Any(x => x.ItemType == ItemType.Wood) &&
                        actorInventory.Any(x => x.ItemType == ItemType.Iron))
                    {
                        this.AddToPerson(actor, new Weapon(craftedItemName));
                    }

                    break;
            }
        }

        private void HandleGatherInteraction(Person actor, string gatheredItemName)
        {
            var location = actor.Location;


            if (location is GatheringLocation)
            {
                var locationAsGatheringLocation = location as GatheringLocation;
                if (actor.ListInventory().Any(x => x.ItemType == locationAsGatheringLocation.RequiredItem))
                {
                    var item = locationAsGatheringLocation.ProduceItem(gatheredItemName);
                    actor.AddToInventory(item);
                }

            }
        }
    }
}
