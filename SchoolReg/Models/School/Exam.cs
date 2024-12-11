using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolReg.Models.School
{
    public class Exam
    {
        public int ExamId { get; set; }
        public DateTime Date { get; set; }
        public int? StudentId { get; set; }
        public int? LessonId { get; set; }
        public double Score { get; set; }

        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
