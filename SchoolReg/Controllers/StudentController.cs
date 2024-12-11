using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolReg.Models.School;
using SchoolReg.Models.ViewModel;
using SchoolReg.Services;

namespace SchoolReg.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private List<int> availableClasses = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students.Result);
        }
        public IActionResult Create() 
        {
            var viewModel = new StudentViewModel
            {
                Grades = new SelectList(availableClasses) 
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel s)
        {
            var stundent = new Student { Name = s.Name, Surname = s.Surname, Grade = s.Grade };
            await _studentService.AddStudent(stundent);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id, string name,string surname, int grade)
        {
            var viewModel = new StudentViewModel
            {
                StudentId = id,
                Name = name,
                Surname = surname,
                Grade = grade,
                Grades = new SelectList(availableClasses)
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(StudentViewModel student)
        {
            var s = new Student { StudentId = student.StudentId, Name = student.Name, Surname = student.Surname, Grade = student.Grade };
            await _studentService.UpdateStudent(s);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);

            if (success)
            {
                TempData["SuccessMessage"] = "Student deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Exam not found or could not be deleted.";
                return NotFound();
            }
            
        }

    }
}
