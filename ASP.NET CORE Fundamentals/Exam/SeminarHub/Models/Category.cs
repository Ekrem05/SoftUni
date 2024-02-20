using SeminarHub.Constraints.ValidationValues;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationValues.Category.NameMax)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}