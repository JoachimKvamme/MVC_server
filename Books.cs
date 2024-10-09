public class Book {
    static private int _id = 0;
    public int Id {set; get;}
    public string Title {get; set;}
    public string? Author{get; set;}
    public int? Year {get; set;}
    public string? Place {get; set;}

    public Book(string title, string author, string place, int year) {
        Id = _id++;
        Title = title;
        Author = author;
        Year = year;
        Place = place;
    }

}

public class Model {
    public List<Book> Books {get; set;}
    public Model() {
        Books = new List<Book> {};
    } 
}