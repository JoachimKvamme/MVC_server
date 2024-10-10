using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;

[ApiController]
[Route("booklists")]

public class ListController : ControllerBase 
{
    public static List<Model> _bookLists = new List<Model> {
        new Model(),
        new Model()
    };
 public static void AddBooks(int id, Book book) {
     _bookLists[id].Books.Add(book);
 } 
    
    
    [HttpGet]
    public IEnumerable<Model> Get()
    {
        return _bookLists;
    }

    [HttpGet("{id:int}")]   // GET /api/test2/xyz
    public IEnumerable<Book> GetProject(int id)
    {
    return _bookLists[id].Books;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Model model)
    {
        if (model == null)
        {
            return BadRequest("Model is null");
        }

        _bookLists.Add(new Model());
        return CreatedAtAction(nameof(Post), new {id = model.Id, list = model.Books}, model);
        
    }

    [HttpPost("{id:int}")]

    public IActionResult POSTBook(int id, [FromBody] Book book) {
        _bookLists[id].Books.Add(book);
        return CreatedAtAction(nameof(Post), book);
    } 
}



