using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolReg.Models.School
{
    public class Student
    {
        public int StudentId { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Surname { get; set; }
        public int Grade { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
