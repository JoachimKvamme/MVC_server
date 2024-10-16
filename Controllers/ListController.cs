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

    [HttpGet("{id}")]   // GET /api/test2/xyz
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


    
    // [HttpPost("{id}")]

    // public IActionResult POST(int id, [FromBody] Book book) {
    //     //int i = 0;
    //     if (book == null)
    //     {
    //         return BadRequest("Book is null");
    //     }
    //     //else {
    //       //  i++;
    //     //}
        
    //     //book = new Book("Philosophical Investigations", "Ludwig", "Wittgenstein", "Cambridge", 1953);
        
    //     _bookLists[0].Books.Add(book);
    //     //return CreatedAtAction(nameof(Post), new {_id = book.Id, list = book}, book);
    //     return Ok(book);
    // } 

}

[ApiController]
[Route("booklists/{id:int}")]

public class BookListController : ControllerBase {
    [HttpPost]
    public IActionResult POST(int id, [FromBody] Book book) {
        if (book == null) {
            return BadRequest("Book is null");
        }
        ListController._bookLists[id].Books.Add(book);
        return Ok(book);

    }
}



