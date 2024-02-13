using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Models
{
    public class AdBuyer
    {
        [ForeignKey(nameof(BuyerId))]
        public string BuyerId { get; set; } = string.Empty;
        public IdentityUser Buyer { get; set; } = null!;

        [ForeignKey(nameof(AdId))]
        public int AdId { get; set; }
        public Ad Ad { get; set; } = null!;

    }
}

//⦁	BuyerId – a  string, Primary Key, foreign key (required)
//⦁	Buyer – IdentityUser
//⦁	AdId – an integer, Primary Key, foreign key (required)
//⦁	Ad – Ad
