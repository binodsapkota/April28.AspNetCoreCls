using BlogApp.Application.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Infrastructure.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<BlogPost> _blogRepo;
        public BlogService(IRepository<BlogPost> blogRepo)
        {
            _blogRepo = blogRepo;
        }
        public async Task CreatePostAsync(BlogPost post)
        {
            await _blogRepo.CreateAsync(post);

        }

        public async Task DeletePostAsync(int id)
        {
            await _blogRepo.DeleteAsync(id);
        }

        public async Task<List<BlogPost>> GetAllPostsAsync()
        {
            return await _blogRepo.GetAllAsync();
        }

        public async Task<BlogPost> GetPostByIdAsync(int id)
        {
            return await _blogRepo.GetByIdAsync(id);
        }

        public async Task UpdatePostAsync(BlogPost post)
        {
            await _blogRepo.UpdateAsync(post);
        }
    }
}
