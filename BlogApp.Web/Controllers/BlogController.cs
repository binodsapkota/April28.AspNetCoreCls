using BlogApp.Application.Interfaces;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogService _blogService;
        public BlogController(ILogger<BlogController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var posts = _blogService.GetAllPostsAsync().Result
                .Select(x => new BlogPostViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    Title = x.Title
                });

            return View(posts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new BlogApp.Domain.Entities.BlogPost()
                {
                    Title = model.Title,
                    Content = model.Content
                };
                await _blogService.CreatePostAsync(post);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _blogService.GetPostByIdAsync(id).Result;
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BlogPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new BlogApp.Domain.Entities.BlogPost()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Content = model.Content
                };
                await _blogService.UpdatePostAsync(post);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = _blogService.GetPostByIdAsync(id).Result;
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost("Delete/{id}")]

        public IActionResult DeleteConfirm(int id)
        {
            var post = _blogService.GetPostByIdAsync(id).Result;
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

    }
}
