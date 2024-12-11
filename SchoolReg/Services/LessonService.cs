using Microsoft.EntityFrameworkCore;
using SchoolReg.Models.Data;
using SchoolReg.Models.School;

namespace SchoolReg.Services
{
    public class LessonService: ILessonService
    {
        private readonly AppDbContext _context;
        public LessonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddLesson(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteLessonAsync(int lessonId)
        {
            var lesson = await _context.Lessons
                                   .Include(s => s.Exams)
                                   .FirstOrDefaultAsync(s => s.LessonId == lessonId);
            if (lesson == null)
            {
                return false;
            }
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task UpdateLesson(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }
        
    }
}
