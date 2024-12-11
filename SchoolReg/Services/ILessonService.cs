using SchoolReg.Models.School;

namespace SchoolReg.Services
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessons();
        Task AddLesson(Lesson student);
        Task UpdateLesson(Lesson student);
        Task<bool> DeleteLessonAsync(int lessonId);
    }
}
