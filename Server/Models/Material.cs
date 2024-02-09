﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgrammingPro.Server.Models
{
    public class Material
    {
        [Key]
        public int? Id { get; set; }
        public string? MaterialName { get; set; }
        [ForeignKey("Homework")]
        public int? HomeworkId { get; set; }
        public Homework? Homework { get; set; }
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
