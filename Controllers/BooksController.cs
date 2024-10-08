using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;

[ApiController]
[Route("books")]

public class BooksController : ControllerBase 
{
    private static List<Books> _books = new List<Books> {
        new Books {Id = 1, Title = "Decline and Fall", Author = "Evelyn Waugh", Year = 1927},
        new Books {Id = 2, Title = "Philosophical Investigations", Author = "Ludwig Wittgenstein"},
        new Books {Id = 3, Title = "Philosophy and the Mirror of Nature", Author = "Richard Rorty"}
    };
    [HttpGet]
    public IEnumerable<Books> Get()
    {
        return _books;
    }
    [HttpPost]
    public IActionResult Post([FromBody] Books books)
    {
        if (books == null)
        {
            return BadRequest("Books is null");
        }

        _books.Add(books);
        return CreatedAtAction(nameof(Post), new {id = books.Id, title = books.Title, author = books.Author, year = books.Year, isbn = books.ISBN}, books);
        
    }
}