using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using static SoftUniBazar.Constraints.ValidationValues;

namespace SoftUniBazar.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AdConstraints.MaxName)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Ad>Ads =new HashSet<Ad>();

    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Name – a string with min length 3 and max length 15 (required)
//⦁	Has Ads – a collection of type Ad
