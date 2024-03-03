using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPro.Shared.Dtos
{
    public class MaterialDto
    {
        public int? Id { get; set; }
        public string? MaterialName { get; set; }
        public byte[]? MaterialContent { get; set; }
        public int? HomeworkId { get; set; }
        public int? LessonId { get; set; }
        public int? CourseId { get; set; }
    }
}
