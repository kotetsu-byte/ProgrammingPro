using System.ComponentModel.DataAnnotations;

namespace ProgrammingPro.Server.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Email {  get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}
