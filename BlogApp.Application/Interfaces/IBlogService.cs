using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Interfaces
{
    public interface IBlogService
    {
        // Define methods for blog service
        Task<List<BlogPost>> GetAllPostsAsync();
        Task<BlogPost> GetPostByIdAsync(int id);
        Task CreatePostAsync(BlogPost post);
        Task UpdatePostAsync(BlogPost post);
        Task DeletePostAsync(int id);
    }
}
