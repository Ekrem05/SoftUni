using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
       
        [Required]
        [MaxLength(7)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(7)]
        [MinLength(2)]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public ImportBoardgameDto[] BoardGames { get; set; }
    }
}
