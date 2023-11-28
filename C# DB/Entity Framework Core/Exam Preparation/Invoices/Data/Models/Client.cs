using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Invoices.Data.Validations;

namespace Invoices.Data.Models
{
    public class Client
    {

        public Client()
        {
            Invoices=new HashSet<Invoice>();
            Addresses=new HashSet<Address>();  
            ProductsClients=new HashSet<ProductClient>();  
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClientNameMax)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ClientNumberVatMax)]
        public string NumberVat { get; set; }

        [Required]
        public ICollection<Invoice> Invoices { get; set; }

        [Required]
        public ICollection<Address> Addresses { get; set; }

        [Required]
        public ICollection<ProductClient> ProductsClients { get; set; }
    }
}
