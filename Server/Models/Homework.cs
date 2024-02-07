using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingPro.Server.Models
{
    public class Homework
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateOnly? Deadline { get; set; }
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
