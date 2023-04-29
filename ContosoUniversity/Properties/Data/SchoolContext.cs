using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var courseBuilder = modelBuilder.Entity<Course>().ToTable("Course");

            //courseBuilder.HasOne(x => x.Department)
            //    .WithMany(x => x.Courses)
            //    .HasForeignKey(x => x.DepartmentID)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    ;

            //var entolmentBuilder = modelBuilder.Entity<Enrollment>().ToTable("Enrollment");

            //entolmentBuilder.HasOne(x => x.Course)
            //   .WithMany(x => x.Enrollments)
            //   .HasForeignKey(x => x.EnrollmentID)
            //   .OnDelete(DeleteBehavior.Restrict)
            //   ;

            //entolmentBuilder.HasOne(x => x.Student)
            //   .WithMany(x => x.Enrollments)
            //   .HasForeignKey(x => x.StudentID)
            //   .OnDelete(DeleteBehavior.Restrict)
            //   ;

            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            modelBuilder.Entity<CourseAssignment>()
            .HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}
