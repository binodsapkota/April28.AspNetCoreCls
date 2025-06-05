using AutoMapper;
using Chapter26.MyWebApiProject.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chapter26.MyWebApiProject.Controllers
{
    [Authorize]
   
    [Route("api/[controller]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly IMapper _mapper;

        private static List<BookModel> books = new()
    {
        new BookModel { Id = 1, Title = "C# Basics", Author = "John Doe" },
        new BookModel { Id = 2, Title = "ASP.NET Core", Author = "Jane Smith" }
    };
        public BookApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET: api/<BookApiController>
        [HttpGet]
        public ActionResult<IEnumerable<BookDto>> Get()
        {

            return Ok(books);
        }

        // GET api/<BookApiController>/5
        [HttpGet("{id}")]
        public ActionResult<BookDto> Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return Ok(book);

        }

        // POST api/<BookApiController>
        [HttpPost]
        public ActionResult Post(BookDto book)
        {
           var data= _mapper.Map<BookModel>(book);
            data.InternalCost = 304;

           
            books.Add(data);
            return CreatedAtAction(nameof(Post), new { id = book.Id }, book);
        }

        // PUT api/<BookApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
