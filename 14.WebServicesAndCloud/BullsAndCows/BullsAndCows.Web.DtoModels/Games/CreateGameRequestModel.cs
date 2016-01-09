namespace BullsAndCows.Web.DtoModels.Games
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CreateGameRequestModel : BaseGameRequestModel, IValidatableObject
    {
        [Required]
        [MaxLength(GameConstants.MaxGameNameLength)]
        public string Name { get; set; }
    }
}
