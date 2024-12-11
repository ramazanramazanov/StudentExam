using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolReg.Models.School;
using SchoolReg.Models.ViewModel;
using SchoolReg.Services;

namespace SchoolReg.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private List<int> availableClasses = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IActionResult Index()
        {
            var lessons = _lessonService.GetAllLessons();
            return View(lessons.Result);
        }
        public IActionResult Create()
        {
            var viewModel = new LessonViewModel
            {
                Grades = new SelectList(availableClasses)
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel l)
        {
            var lesson = new Lesson { Name = l.Name, Grade = l.Grade, Teachername =l.Teachername, Teachersurname = l.Teachersurname };
            await _lessonService.AddLesson(lesson);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id, string name, int grade, string tname, string tsname)
        {
            var viewModel = new LessonViewModel
            {
                LessonId = id,
                Name = name,
                Teachername = tname,
                Teachersurname = tsname,
                Grade = grade,
                Grades = new SelectList(availableClasses)
            };
            return View("Create", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(LessonViewModel l)
        {
            var lesson = new Lesson { LessonId = l.LessonId,Name=l.Name, Grade = l.Grade, Teachername = l.Teachername, Teachersurname = l.Teachersurname };
            await _lessonService.UpdateLesson(lesson);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var success = await _lessonService.DeleteLessonAsync(id);

            if (success)
            {
                TempData["SuccessMessage"] = "Lesson deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Lesson not found or could not be deleted.";
                return NotFound();
            }

        }
    }
}
