using SeminarHub.Constraints.ErrorMessages;
using SeminarHub.Constraints.ValidationValues;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(ValidationValues.Category.NameMax, MinimumLength = ValidationValues.Category.NameMin, ErrorMessage = ErrorMessages.invalidValueString)]
        public string Name { get; set; } = string.Empty;
    }
}