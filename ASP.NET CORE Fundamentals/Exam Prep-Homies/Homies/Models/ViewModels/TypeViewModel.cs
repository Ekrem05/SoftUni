using System.ComponentModel.DataAnnotations;

namespace Homies.Models.ViewModels
{
    public class TypeViewModel
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; } = null!;
    }
}