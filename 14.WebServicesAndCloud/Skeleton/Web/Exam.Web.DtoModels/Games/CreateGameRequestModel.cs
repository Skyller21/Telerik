namespace Exam.Web.DtoModels.Games
{
    using System.ComponentModel.DataAnnotations;
    using Exam.Web.Common.Constants;

    public class CreateGameRequestModel : BaseGameRequestModel, IValidatableObject
    {
        [Required]
        [MaxLength(GameConstants.MaxGameNameLength)]
        public string Name { get; set; }
    }
}
