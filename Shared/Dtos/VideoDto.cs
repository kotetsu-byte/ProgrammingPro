using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPro.Shared.Dtos
{
    public class VideoDto
    {
        public int? Id { get; set; }
        public string? VideoName { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
