using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Models;
using System.ComponentModel;

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

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course 
                    { 
                        Id = 1,
                        Name = "C++",
                        Description = "",
                        ImgName = ""
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "C#",
                        Description = "",
                        ImgName = ""
                    },
                    new Course
                    {
                        Id = 3,
                        Name = "Java",
                        Description = "",
                        ImgName = ""
                    },
                    new Course
                    {
                        Id = 4,
                        Name = "Python",
                        Description = "",
                        ImgName = ""
                    },
                    new Course
                    {
                        Id = 5,
                        Name = "Ruby",
                        Description = "",
                        ImgName = ""
                    },
                    new Course
                    {
                        Id = 6,
                        Name = "PHP",
                        Description = "",
                        ImgName = ""
                    }
                );

            modelBuilder.Entity<Lesson>()
                .HasData(
                    // C++
                    new Lesson
                    { 
                        Id = 1,
                        CourseId = 1,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 2,
                        CourseId = 1,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 3,
                        CourseId = 1,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 4,
                        CourseId = 1,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 5,
                        CourseId = 1,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 6,
                        CourseId = 1,
                        Text = ""
                    },
                    // C#
                    new Lesson
                    {
                        Id = 7,
                        CourseId = 2,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 8,
                        CourseId = 2,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 9,
                        CourseId = 2,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 10,
                        CourseId = 2,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 11,
                        CourseId = 2,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 12,
                        CourseId = 2,
                        Text = ""
                    },
                    // Java
                    new Lesson
                    {
                        Id = 13,
                        CourseId = 3,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 14,
                        CourseId = 3,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 15,
                        CourseId = 3,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 16,
                        CourseId = 3,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 17,
                        CourseId = 3,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 18,
                        CourseId = 3,
                        Text = ""
                    },
                    // Python
                    new Lesson
                    {
                        Id = 19,
                        CourseId = 4,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 20,
                        CourseId = 4,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 21,
                        CourseId = 4,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 22,
                        CourseId = 4,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 23,
                        CourseId = 4,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 24,
                        CourseId = 4,
                        Text = ""
                    },
                    // Ruby
                    new Lesson
                    {
                        Id = 25,
                        CourseId = 5,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 26,
                        CourseId = 5,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 27,
                        CourseId = 5,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 28,
                        CourseId = 5,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 29,
                        CourseId = 5,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 30,
                        CourseId = 5,
                        Text = ""
                    },
                    // PHP
                    new Lesson
                    {
                        Id = 31,
                        CourseId = 6,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 32,
                        CourseId = 6,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 33,
                        CourseId = 6,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 34,
                        CourseId = 6,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 35,
                        CourseId = 6,
                        Text = ""
                    },
                    new Lesson
                    {
                        Id = 36,
                        CourseId = 6,
                        Text = ""
                    }
                );

            modelBuilder.Entity<Test>()
                .HasData(
                    // C++
                    new Test
                    {
                        Id = 1,
                        CourseId = 1,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 2,
                        CourseId = 1,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 3,
                        CourseId = 1,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 4,
                        CourseId = 1,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 5,
                        CourseId = 1,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 6,
                        CourseId = 1,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    // C#
                    new Test
                    {
                        Id = 7,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 8,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 9,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 10,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 11,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 12,
                        CourseId = 2,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    // Java
                    new Test
                    {
                        Id = 13,
                        CourseId = 3,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 14,
                        CourseId = 3,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 15,
                        CourseId = 3,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 16,
                        CourseId = 3,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 17,
                        CourseId = 3,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 18,
                        CourseId = 3,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    // Python
                    new Test
                    {
                        Id = 19,
                        CourseId = 4,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 20,
                        CourseId = 4,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 21,
                        CourseId = 4,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 22,
                        CourseId = 4,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 23,
                        CourseId = 4,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 24,
                        CourseId = 4,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    // Ruby
                    new Test
                    {
                        Id = 25,
                        CourseId = 5,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 26,
                        CourseId = 5,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 27,
                        CourseId = 5,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 28,
                        CourseId = 5,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 29,
                        CourseId = 5,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 30,
                        CourseId = 5,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    // PHP
                    new Test
                    {
                        Id = 31,
                        CourseId = 6,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 32,
                        CourseId = 6,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 33,
                        CourseId = 6,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 34,
                        CourseId = 6,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 35,
                        CourseId = 6,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    },
                    new Test
                    {
                        Id = 36,
                        CourseId = 6,
                        Question = "",
                        Answer1 = "",
                        Answer2 = "",
                        Answer3 = "",
                        Answer4 = "",
                        CorrectAnswer = 0,
                        Points = 0
                    }
                );

            modelBuilder.Entity<Doc>()
                .HasData(
                    // C++
                    new Doc
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        DocName = ""
                    },
                    // C#
                    new Doc
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        DocName = ""
                    },
                    // Java
                    new Doc
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        DocName = ""
                    },
                    // Python
                    new Doc
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        DocName = ""
                    },
                    // Ruby
                    new Doc
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        DocName = ""
                    }, 
                    new Doc
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        DocName = ""
                    }, 
                    new Doc
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        DocName = ""
                    },
                    // PHP
                    new Doc
                    {
                        Id = 31,
                        CourseId = 6,
                        LessonId = 31,
                        DocName = ""
                    }
                    , new Doc
                    {
                        Id = 32,
                        CourseId = 6,
                        LessonId = 32,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 33,
                        CourseId = 6,
                        LessonId = 33,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 34,
                        CourseId = 6,
                        LessonId = 34,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 35,
                        CourseId = 6,
                        LessonId = 35,
                        DocName = ""
                    },
                    new Doc
                    {
                        Id = 36,
                        CourseId = 6,
                        LessonId = 36,
                        DocName = ""
                    }
                );

            modelBuilder.Entity<Video>()
                .HasData(
                    // C++
                    new Video
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        VideoName = ""
                    },
                    // C#
                    new Video
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        VideoName = ""
                    },
                    // Java
                    new Video
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        VideoName = ""
                    },
                    // Python
                    new Video
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        VideoName = ""
                    },
                    // Ruby
                    new Video
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        VideoName = ""
                    },
                    // PHP
                    new Video
                    {
                        Id = 31,
                        CourseId = 6,
                        LessonId = 31,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 32,
                        CourseId = 6,
                        LessonId = 32,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 33,
                        CourseId = 6,
                        LessonId = 33,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 34,
                        CourseId = 6,
                        LessonId = 34,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 35,
                        CourseId = 6,
                        LessonId = 35,
                        VideoName = ""
                    },
                    new Video
                    {
                        Id = 36,
                        CourseId = 6,
                        LessonId = 36,
                        VideoName = ""
                    }
                );

            modelBuilder.Entity<Homework>()
                .HasData(
                    // C++
                    new Homework
                    {
                        Id = 1,
                        CourseId = 1,
                        LessonId = 1,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 2,
                        CourseId = 1,
                        LessonId = 2,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 3,
                        CourseId = 1,
                        LessonId = 3,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 4,
                        CourseId = 1,
                        LessonId = 4,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 5,
                        CourseId = 1,
                        LessonId = 5,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 6,
                        CourseId = 1,
                        LessonId = 6,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    // C#
                    new Homework
                    {
                        Id = 7,
                        CourseId = 2,
                        LessonId = 7,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 8,
                        CourseId = 2,
                        LessonId = 8,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 9,
                        CourseId = 2,
                        LessonId = 9,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 10,
                        CourseId = 2,
                        LessonId = 10,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 11,
                        CourseId = 2,
                        LessonId = 11,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 12,
                        CourseId = 2,
                        LessonId = 12,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    // Java
                    new Homework
                    {
                        Id = 13,
                        CourseId = 3,
                        LessonId = 13,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 14,
                        CourseId = 3,
                        LessonId = 14,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 15,
                        CourseId = 3,
                        LessonId = 15,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 16,
                        CourseId = 3,
                        LessonId = 16,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 17,
                        CourseId = 3,
                        LessonId = 17,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 18,
                        CourseId = 3,
                        LessonId = 18,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    // Python
                    new Homework
                    {
                        Id = 19,
                        CourseId = 4,
                        LessonId = 19,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 20,
                        CourseId = 4,
                        LessonId = 20,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 21,
                        CourseId = 4,
                        LessonId = 21,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 22,
                        CourseId = 4,
                        LessonId = 22,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 23,
                        CourseId = 4,
                        LessonId = 23,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 24,
                        CourseId = 4,
                        LessonId = 24,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    // Ruby
                    new Homework
                    {
                        Id = 25,
                        CourseId = 5,
                        LessonId = 25,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 26,
                        CourseId = 5,
                        LessonId = 26,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 27,
                        CourseId = 5,
                        LessonId = 27,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 28,
                        CourseId = 5,
                        LessonId = 28,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 29,
                        CourseId = 5,
                        LessonId = 29,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 30,
                        CourseId = 5,
                        LessonId = 30,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    // PHP
                    new Homework
                    {
                        Id = 31,
                        CourseId = 6,
                        LessonId = 31,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 32,
                        CourseId = 6,
                        LessonId = 32,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 33,
                        CourseId = 6,
                        LessonId = 33,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 34,
                        CourseId = 6,
                        LessonId = 34,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 35,
                        CourseId = 6,
                        LessonId = 35,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    },
                    new Homework
                    {
                        Id = 36,
                        CourseId = 6,
                        LessonId = 36,
                        Title = "",
                        Content = "",
                        Deadline = new DateOnly(2024, 6, 15)
                    }
                );

        }
    }
}
