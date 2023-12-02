using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models
{
    public class ClientTruck
    {
        [ForeignKey(nameof(ClientId))]
        public int ClientId { get; set; }
        public Client Client { get; set; }


        [ForeignKey(nameof(TruckId))]
        public int TruckId { get; set; }    
        public Truck Truck { get; set; }    
    }
}