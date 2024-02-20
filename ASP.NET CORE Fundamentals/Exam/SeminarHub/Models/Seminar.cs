using Microsoft.AspNetCore.Identity;
using SeminarHub.Constraints.ValidationValues;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Models
{
    public class Seminar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationValues.Seminar.TopicMax)]
        public string Topic { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationValues.Seminar.LecturerMax)]
        public string Lecturer { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationValues.Seminar.DetailsMax)]
        public string Details { get; set; } = string.Empty;

        [Required]
        public string OrganizerId { get; set; } = string.Empty;
        [Required]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        [MaxLength(ValidationValues.Seminar.DurationMax)]
        public int Duration { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; } = null!;

        public ICollection<SeminarParticipant> SeminarsParticipants { get; set; } = new HashSet<SeminarParticipant>();

    }
}