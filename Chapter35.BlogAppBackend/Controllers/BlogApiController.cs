using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chapter35.BlogAppBackend;
using Chapter35.BlogAppBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace Chapter35.BlogAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogApiController : ControllerBase
    {
        private readonly BlogDbContext _context;

        public BlogApiController(BlogDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostModel>>> GetBlogPosts()
        {
            return await _context.BlogPosts.ToListAsync();
        }

        // GET: api/BlogApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostModel>> GetBlogPostModel(int id)
        {
            var blogPostModel = await _context.BlogPosts.FindAsync(id);

            if (blogPostModel == null)
            {
                return NotFound();
            }

            return blogPostModel;
        }

        // PUT: api/BlogApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPostModel(int id, BlogPostModel blogPostModel)
        {
            if (id != blogPostModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogPostModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogPostModel>> PostBlogPostModel(BlogPostModel blogPostModel)
        {
            _context.BlogPosts.Add(blogPostModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPostModel", new { id = blogPostModel.Id }, blogPostModel);
        }

        // DELETE: api/BlogApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPostModel(int id)
        {
            var blogPostModel = await _context.BlogPosts.FindAsync(id);
            if (blogPostModel == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPostModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogPostModelExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }
    }
}
