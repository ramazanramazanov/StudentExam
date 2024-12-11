using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolReg.Models.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Grade { get; set; }
        public SelectList Grades { get; set; }
    }
}
