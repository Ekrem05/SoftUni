using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.Data.Models
{
    [XmlType("asdasd")]
    public class Despatcher
    {
        public Despatcher()
        {
                Trucks=new HashSet<Truck>();    
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string Position  { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}