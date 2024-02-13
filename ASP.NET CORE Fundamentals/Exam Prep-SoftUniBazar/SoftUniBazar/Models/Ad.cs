using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using static SoftUniBazar.Constraints.ValidationValues;
namespace SoftUniBazar.Models
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AdConstraints.MaxName)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(AdConstraints.MaxDescription)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [Required]
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<AdBuyer> AdBuyers = new HashSet<AdBuyer>();

    }
}
//⦁	Has Id – a unique integer, Primary Key
//⦁	Has Name – a string with min length 5 and max length 25 (required)
//⦁	Has Description – a string with min length 15 and max length 250 (required)
//⦁	Has Price – a decimal (required)
//⦁	Has OwnerId – a string (required)
//⦁	Has Owner – an IdentityUser (required)
//⦁	Has ImageUrl – a string (required)
//⦁	Has CreatedOn – a DateTime with format "yyyy-MM-dd H:mm" (required) (the DateTime format is recommended, if you are having troubles with this one, you are free to use another one)
//⦁	Has CategoryId – an integer, foreign key (required)
//⦁	Has Category – a Category (required)
