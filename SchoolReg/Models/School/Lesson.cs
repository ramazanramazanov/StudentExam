using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolReg.Models.School
{
    public class Lesson
    {
        public int LessonId { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        public int Grade { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Teachername { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Teachersurname { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
