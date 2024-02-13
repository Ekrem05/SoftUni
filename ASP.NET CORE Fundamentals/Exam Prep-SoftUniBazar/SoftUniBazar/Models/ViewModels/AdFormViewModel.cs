using Microsoft.AspNetCore.Identity;
using static SoftUniBazar.Constraints.ValidationValues;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SoftUniBazar.Constraints;

namespace SoftUniBazar.Models.ViewModels
{
    public class AdFormViewModel
    {
        [Required(ErrorMessage =ErrorMessages.RequiredField)]
        [StringLength(AdConstraints.MaxName,MinimumLength =AdConstraints.MinName,ErrorMessage =ErrorMessages.InvalidStringValueMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(AdConstraints.MaxDescription, MinimumLength = AdConstraints.MinDescription, ErrorMessage = ErrorMessages.InvalidStringValueMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
