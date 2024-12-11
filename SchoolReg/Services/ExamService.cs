using Microsoft.EntityFrameworkCore;
using SchoolReg.Models.Data;
using SchoolReg.Models.School;

namespace SchoolReg.Services
{
    public class ExamService: IExamService
    {
        private readonly AppDbContext _context;
        public ExamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteExamAsync(int examId)
        {
            var exam = await _context.Exams.FindAsync(examId);
            if (exam == null)
            {
                return false; 
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<List<Exam>> GetAllExams()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task UpdateExam(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }
    }
}
