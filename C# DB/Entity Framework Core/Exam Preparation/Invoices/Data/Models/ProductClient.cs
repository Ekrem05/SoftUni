

using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models
{
    public class ProductClient
    {
        [ForeignKey(nameof(ProductId))]
        public int ProductId{ get; set; }
        public Product Product { get; set; }


        [ForeignKey(nameof(ClientId))]
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}