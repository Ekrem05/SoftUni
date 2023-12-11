using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizen
    {
        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string MaritalStatus { get; set;}

        public int[] Properties { get; set;}
    }
}
