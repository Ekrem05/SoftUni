using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
                Homeworks=new List<Homework>();
                Resources = new List<Resource>();
                StudentsCourses = new List<StudentCourse>();

        }
        [Key]
        public int CourseId { get; set; }

        [Column("Name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column("Description", TypeName="nvarchar(80)")]
        [AllowNull]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column("Price", TypeName = "money")]

        public decimal Price { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }


    }
}
