using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPro.Shared.Dtos
{
    public class HomeworkDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateOnly? Deadline { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
