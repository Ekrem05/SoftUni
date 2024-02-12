using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Models
{
    public class EventParticipant
    {
        [ForeignKey(nameof(HelperId))]
        public string HelperId { get; set; } = null!;
        public IdentityUser Helper { get; set; } = null!;

        [ForeignKey(nameof(EventId))]
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;



    }
}
//⦁	HelperId – a  string, Primary Key, foreign key (required)
//⦁	Helper – IdentityUser
//⦁	EventId – an integer, Primary Key, foreign key (required)
//⦁	Event – Event
