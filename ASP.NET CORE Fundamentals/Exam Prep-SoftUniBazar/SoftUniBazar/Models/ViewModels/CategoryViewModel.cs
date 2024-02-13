using static SoftUniBazar.Constraints.ValidationValues;
using System.ComponentModel.DataAnnotations;
using SoftUniBazar.Constraints;

namespace SoftUniBazar.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(CategoryConstraints.MaxName, MinimumLength = CategoryConstraints.MinName, ErrorMessage = ErrorMessages.InvalidStringValueMessage)]
        public string Name { get; set; } = string.Empty;
    }
}