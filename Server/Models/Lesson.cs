using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingPro.Server.Models
{
    public class Lesson
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
