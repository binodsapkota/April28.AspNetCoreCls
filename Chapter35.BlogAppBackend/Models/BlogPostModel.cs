using System.ComponentModel.DataAnnotations;

namespace Chapter35.BlogAppBackend.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Author { get; set; } = string.Empty;
    }
}
