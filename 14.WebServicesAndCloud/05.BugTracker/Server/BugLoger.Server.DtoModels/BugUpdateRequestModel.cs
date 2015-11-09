namespace BugLogger.Server.DtoModels
{
    using AutoMapper;
    using Common.Mapping;
    using Models;

    public class BugUpdateRequestModel : IMapFrom<Bug>, IHaveCustomMappings
    {
        public string Text { get; set; }

        public string Status { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<BugUpdateRequestModel, Bug>();
        }
    }
}
