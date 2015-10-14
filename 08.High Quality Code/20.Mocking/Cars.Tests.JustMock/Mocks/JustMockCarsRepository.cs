namespace Cars.Tests.JustMock.Mocks
{
    using System.Linq;

    using Cars.Contracts;
    using Cars.Models;

    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoInstead((Car car) => this.FakeCarCollection.Add(car));
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString)).Returns((string s) => this.FakeCarCollection
                .Where(c => c.Make.ToLower() == s.ToLower() || c.Model.ToLower() == s.ToLower()).ToList());
            Mock.Arrange(() => this.CarsData.GetById(Arg.AnyInt)).Returns((int id) => this.FakeCarCollection.FirstOrDefault(c => c.Id == id));
            Mock.Arrange(() => this.CarsData.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());
        }
    }
}
