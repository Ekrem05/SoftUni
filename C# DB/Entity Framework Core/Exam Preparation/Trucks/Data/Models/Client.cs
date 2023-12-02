using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Data.Models
{
   
    public class Client
    {

        public Client()
        {
                ClientsTrucks=new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nationality  { get; set; }

        [Required]
        public string Type  { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
