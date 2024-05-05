using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPro.Shared.Dtos
{
    public class TestDto
    {
        public int? Id { get; set; }
        public string? Question { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public int? CorrectAnswer { get; set; }
        public int? CourseId { get; set; }
    }
}
