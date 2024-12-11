using Microsoft.EntityFrameworkCore;
using SchoolReg.Models.School;

namespace SchoolReg.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
               .Property(u => u.LessonId)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>()
               .Property(u => u.StudentId)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Exam>()
               .Property(u => u.ExamId)
               .ValueGeneratedOnAdd();


            modelBuilder.Entity<Exam>()
            .HasOne(e => e.Student)           
            .WithMany(s => s.Exams)           
            .HasForeignKey(e => e.StudentId)  
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exam>()
            .HasOne(e => e.Lesson)           
            .WithMany(s => s.Exams)           
            .HasForeignKey(e => e.LessonId)  
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
