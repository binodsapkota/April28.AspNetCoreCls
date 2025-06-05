using System.Text.Json.Serialization;

namespace Chapter26.MyWebApiProject.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [JsonIgnore]
        public decimal InternalCost { get; set; }

    }
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
