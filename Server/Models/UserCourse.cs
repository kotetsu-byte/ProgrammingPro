namespace ProgrammingPro.Server.Models
{
    public class UserCourse
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
