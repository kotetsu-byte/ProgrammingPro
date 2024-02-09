using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingPro.Server.Models
{
    public class Video
    {
        [Key]
        public int? Id { get; set; }
        public string? VideoName { get; set; }
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
