using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolReg.Models.School;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolReg.Models.ViewModel
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public string Teachername { get; set; }
        public string Teachersurname { get; set; }
        public SelectList Grades { get; set; }
    }
}
