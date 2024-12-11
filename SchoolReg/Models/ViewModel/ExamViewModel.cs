using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolReg.Models.School;

namespace SchoolReg.Models.ViewModel
{
    public class ExamViewModel
    {
        public int ExamId { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public double Score { get; set; }

        public List<SelectListItem> Students { get; set; }
        public List<SelectListItem> Lessons { get; set; }
        public SelectList Scores { get; set; }
    }
}
