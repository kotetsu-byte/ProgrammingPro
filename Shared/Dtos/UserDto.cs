using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPro.Shared.Dtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Email { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
    }
}
