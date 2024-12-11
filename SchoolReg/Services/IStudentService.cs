using SchoolReg.Models.School;

namespace SchoolReg.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
