public class Name {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public Name (string firstName, string lastName) {
        FirstName = firstName;
        LastName = lastName;
    }
}


public class Book {
    static private int _id = 0;
    public int Id {set; get;}
    public string Title {get; set;}
    public string FirstNameAuthor{get; set;}
    public string LastNameAuthor {get; set;}
    public int? Year {get; set;}
    public string? Place {get; set;}

    public Book(string title, string firstName, string lastName, string place, int year) {
        Id = _id++;
        Title = title;
        FirstNameAuthor = firstName;
        LastNameAuthor = lastName;
        Year = year;
        Place = place;
    }

}

public class Model {
    static private int _id = 0;
    public int Id {get; set;}
    public List<Book> Books {get; set;}
    public Model() {
        Id = _id++;
        Books = new List<Book> {};
    } 
}