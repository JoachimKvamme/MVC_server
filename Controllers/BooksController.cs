using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;

[ApiController]
[Route("books")]

public class BooksController : ControllerBase 
{
    private static List<Book> _books = new List<Book> {

        new Book("Decline and Fall", new Name("Evelyn", "Waugh"), "London", 1925),
        new Book("Philosophical Investigations", new Name("Ludwig", "Wiittgenstein"), "Cambridge", 1949),
        new Book("Philosophy and the Mirror of nature", new Name("Richard", "Rorty"), "Pittsburg", 1979)
    };
    [HttpGet]
    public IEnumerable<Book> Get()
    {
        return _books;
    }
    [HttpPost]
    public IActionResult Post([FromBody] Book books)
    {
        if (books == null)
        {
            return BadRequest("Books is null");
        }

        _books.Add(books);
        return CreatedAtAction(nameof(Post), new {id = books.Id, title = books.Title, author = books.Author, year = books.Year, place = books.Place}, books);
        
    }
}