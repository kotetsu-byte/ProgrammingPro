using System.ComponentModel.DataAnnotations;

namespace ProgrammingPro.Server.Models
{
    public class Course
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
