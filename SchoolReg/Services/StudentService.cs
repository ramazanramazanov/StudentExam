using Microsoft.EntityFrameworkCore;
using SchoolReg.Models.Data;
using SchoolReg.Models.School;

namespace SchoolReg.Services
{
    public class StudentService: IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students
                                    .Include(s => s.Exams) 
                                    .FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null)
            {
                return false;
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync(); 
        }
        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);  
            await _context.SaveChangesAsync();  
        }
    }
}
