using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPro.Shared.Dtos
{
    public class DocDto
    {
        public int? Id { get; set; }
        public string? DocName { get; set; }
        public byte[]? DocContent { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
