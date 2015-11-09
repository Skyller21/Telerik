namespace _01.NorthwindDbContext
{
    using System.Data.Linq;
    using _01.NorthwindDbContext;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesSet
        {
            get
            {
                EntitySet<Territory> territoriesSet = new EntitySet<Territory>();
                territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}
