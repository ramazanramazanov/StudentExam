using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolReg.Models.School;
using SchoolReg.Models.ViewModel;
using SchoolReg.Services;

namespace SchoolReg.Controllers
{
    public class ExamController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;
        private readonly IExamService _examService;
        private List<Student> availableStudents = new List<Student>();
        private List<Lesson> availableLessons = new List<Lesson>();
        private List<int> availableScores = new List<int> { 1, 2, 3, 4, 5 };
        public ExamController(IStudentService studentService,ILessonService lessonService, IExamService examService)
        {
            _studentService = studentService;
            _lessonService = lessonService;
            _examService = examService;
        }
        public IActionResult Index()
        {
            var exams = _examService.GetAllExams().Result;
            foreach (var exam in exams)
            {
                foreach (var lesson in _lessonService.GetAllLessons().Result)
                {
                    if(exam.LessonId==lesson.LessonId)
                    {
                        exam.Lesson = lesson;
                        break;
                    }
                }
                foreach (var student in _studentService.GetAllStudents().Result)
                {
                    if (exam.StudentId == student.StudentId)
                    {
                        exam.Student = student;
                        break;
                    }
                }
            }
            return View(exams);
        }

        public IActionResult Create()
        {
            var lessons = GetLessons();
            var students = GetStudents();
            var viewModel = new ExamViewModel
            {
                Students = students,
                Lessons = lessons,
                Scores = new SelectList(availableScores),
                Date= DateTime.Now,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamViewModel e)
        {
            var exam = new Exam { StudentId = e.StudentId, LessonId = e.LessonId, Score = e.Score, Date = e.Date };
            await _examService.AddExam(exam);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id, int sid, int lid, int score,string date)
        {
            var lessons = GetLessons();
            var students = GetStudents();
           
            var viewModel = new ExamViewModel
            {
                ExamId = id,
                StudentId = sid,
                LessonId = lid,
                Score = score,
                Scores = new SelectList(availableScores),
                Students = students,
                Lessons = lessons,
                Date = DateTime.Parse(date),
            };
            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ExamViewModel e)
        {
            var exam = new Exam { StudentId = e.StudentId, LessonId = e.LessonId, Score = e.Score, Date = e.Date };
            await _examService.UpdateExam(exam);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _examService.DeleteExamAsync(id);

            if (success)
            {
                TempData["SuccessMessage"] = "Exam deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Exam not found or could not be deleted.";
            }

            return RedirectToAction(nameof(Index)); 
        }

        public List<SelectListItem> GetStudents()
        {
            var students = _studentService.GetAllStudents().Result
            .Select(s => new SelectListItem
             {
                 Value = s.StudentId.ToString(),
                 Text = $"{s.Name} {s.Surname}"
             })
                                  .ToList();
            return students;
        }
        public List<SelectListItem> GetLessons()
        {
            var lessons = _lessonService.GetAllLessons().Result
            .Select(s => new SelectListItem
            {
                Value = s.LessonId.ToString(),
                Text = $"{s.Grade} sinif {s.Name}"
            })
             .ToList();
            return lessons;
        }
    }
}
