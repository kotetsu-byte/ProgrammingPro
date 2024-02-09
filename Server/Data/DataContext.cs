using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
                .HasOne(c => c.Course)
                .WithMany(l => l.Lessons)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Test>()
                .HasOne(c => c.Course)
                .WithMany(t => t.Tests)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doc>()
                .HasOne(l => l.Lesson)
                .WithMany(d => d.Docs)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Video>()
                .HasOne(l => l.Lesson)
                .WithMany(v => v.Videos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Homework>()
                .HasOne(l => l.Lesson)
                .WithMany(h => h.Homeworks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasOne(h => h.Homework)
                .WithMany(m => m.Materials)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });
            modelBuilder.Entity<UserCourse>()
                .HasOne(c => c.Course)
                .WithMany(uc => uc.UserCourses)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserCourse>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserCourses)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
