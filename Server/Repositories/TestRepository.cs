﻿using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Data;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;

        public TestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Test>> GetAllTests(int courseId)
        {
            return await _context.Tests.Where(t => t.CourseId == courseId).ToListAsync();
        }

        public async Task<Test> GetTestById(int courseId, int id)
        {
            return await _context.Tests.Where(t => t.CourseId == courseId && t.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Test test)
        {
            _context.Tests.Add(test);

            return Save();
        }

        public bool Update(Test test)
        {
            _context.Tests.Update(test);

            return Save();
        }

        public bool Delete(int id)
        {
            var test = _context.Tests.Where(t => t.Id == id).FirstOrDefault();
            
            _context.Tests.Remove(test);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
