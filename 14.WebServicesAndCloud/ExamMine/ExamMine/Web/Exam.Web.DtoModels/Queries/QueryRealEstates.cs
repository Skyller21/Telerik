namespace Exam.Web.DtoModels.Queries
{
    using System.ComponentModel.DataAnnotations;

    public class QueryRealEstates
    {
        public int? Skip { get; set; }

        [Range(0, 100)]
        public int? Take { get; set; }
    }
}
