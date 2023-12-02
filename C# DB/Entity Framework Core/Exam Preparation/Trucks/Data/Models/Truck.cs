using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {

        public Truck()
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public string  RegistrationNumber { get; set; }

        [Required]
        [MaxLength(17)]
        public string VinNumber  { get; set; }

        [Required]
        public int TankCapacity { get; set; }

        [Required]
        public int CargoCapacity  { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [ForeignKey(nameof(DespatcherId))]
        public int DespatcherId { get; set; }
        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
