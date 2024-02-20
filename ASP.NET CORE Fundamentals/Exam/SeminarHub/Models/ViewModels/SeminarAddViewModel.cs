using SeminarHub.Constraints.ErrorMessages;
using SeminarHub.Constraints.ValidationValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Models.ViewModels
{
    public class SeminarAddViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(ValidationValues.Seminar.TopicMax, MinimumLength = ValidationValues.Seminar.TopicMin, ErrorMessage = ErrorMessages.invalidValueString)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(ValidationValues.Seminar.LecturerMax, MinimumLength = ValidationValues.Seminar.LecturerMin, ErrorMessage = ErrorMessages.invalidValueString)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(ValidationValues.Seminar.DetailsMax, MinimumLength = ValidationValues.Seminar.DetailsMin, ErrorMessage = ErrorMessages.invalidValueString)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string DateAndTime { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [Range(ValidationValues.Seminar.DurationMin, ValidationValues.Seminar.DurationMax, ErrorMessage = ErrorMessages.invalidValueInteger)]
        public int Duration { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories = new List<CategoryViewModel>();
    }
}
