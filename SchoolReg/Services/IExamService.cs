using SchoolReg.Models.School;

namespace SchoolReg.Services
{
    public interface IExamService
    {
        Task<List<Exam>> GetAllExams();
        Task AddExam(Exam exam);
        Task UpdateExam(Exam exam);
        Task<bool> DeleteExamAsync(int examId);
    }
}
