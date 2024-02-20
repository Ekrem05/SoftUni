using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Models
{
    public class SeminarParticipant
    {
        [ForeignKey(nameof(SeminarId))]
        public int SeminarId { get; set; }
        public Seminar Seminar { get; set; } = null!;

        [ForeignKey(nameof(ParticipantId))]
        public string ParticipantId { get; set; } = string.Empty;
        public IdentityUser Participant = null!;
    }
}