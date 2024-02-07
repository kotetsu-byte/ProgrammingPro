﻿using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Data;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly DataContext _context;

        public HomeworkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Homework>> GetAllHomeworks(int courseId, int lessonId)
        {
            return await _context.Homeworks.Where(h => h.CourseId == courseId && h.LessonId == lessonId).ToListAsync();
        }

        public async Task<Homework> GetHomeworkById(int courseId, int lessonId, int id)
        {
            return await _context.Homeworks.Where(h => h.CourseId == courseId && h.LessonId == lessonId && h.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Homework homework)
        {
            _context.Homeworks.Add(homework);

            return Save();
        }

        public bool Update(Homework homework)
        {
            _context.Homeworks.Update(homework);

            return Save();
        }

        public bool Delete(int id)
        {
            var homework = _context.Homeworks.Where(h => h.Id == id).FirstOrDefault();

            _context.Homeworks.Remove(homework);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
