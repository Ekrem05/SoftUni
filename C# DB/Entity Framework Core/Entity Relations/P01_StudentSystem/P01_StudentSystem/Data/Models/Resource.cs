using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
       
        public ResourceType ResourceType {get; set; }   

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }


    }
}
