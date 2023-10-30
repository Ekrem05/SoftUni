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
    public class Student
    {
        public Student()
        {
            Homeworks = new List<Homework>();
            StudentsCourses = new List<StudentCourse>();


        }
        [Key]
        public int StudentId { get; set; }
        [Column("Name", TypeName="nvarchar(100)")]
        public string? Name { get; set; }
        [Column("PhoneNumber", TypeName = "char(10)")]
        public string? PhoneNumber { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public DateTime? Birthday{ get; set; }
        public ICollection<Homework> Homeworks { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }


    }
}
