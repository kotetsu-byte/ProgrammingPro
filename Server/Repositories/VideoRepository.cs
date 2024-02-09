﻿using Microsoft.EntityFrameworkCore;
using ProgrammingPro.Server.Data;
using ProgrammingPro.Server.Interfaces;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Video>> GetAllVideos(int courseId, int lessonId)
        {
            return await _context.Videos.Where(v => v.CourseId == courseId && v.LessonId == lessonId).ToListAsync();
        }

        public async Task<Video> GetVideoById(int courseId, int lessonId, int id)
        {
            return await _context.Videos.Where(v => v.CourseId == courseId && v.LessonId == lessonId && v.Id == id).FirstOrDefaultAsync();
        }

        public bool Create(Video video)
        {
            _context.Videos.Add(video);

            return Save();
        }

        public bool Update(Video video)
        {
            _context.Videos.Update(video);

            return Save();
        }

        public bool Delete(int id)
        {
            var video = _context.Videos.Where(v => v.Id == id).FirstOrDefault();

            _context.Videos.Remove(video);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
