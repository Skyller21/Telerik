namespace BullsAndCows.Web.DtoModels.Games
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class BaseGameRequestModel : IValidatableObject
    {

        [Required]
        [MinLength(GameConstants.GuessNumberLength)]
        [MaxLength(GameConstants.GuessNumberLength)]
        public string Number { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var number = this.Number
                .Distinct()
                .Where(char.IsDigit)
                .ToList();

            if (number.Count() != GameConstants.GuessNumberLength)
            {
                yield return new ValidationResult("Numbers must be distict digits");
            }
        }
    }
}
