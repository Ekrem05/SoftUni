using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            BoardgamesSellers=new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public double Rating  { get; set; }

        [Required]
        public int YearPublished  { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; }

        [ForeignKey(nameof(CreatorId))]
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
