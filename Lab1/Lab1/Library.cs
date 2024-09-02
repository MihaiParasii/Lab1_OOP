namespace Lab1;

public class Library
{
    private readonly ICollection<Book> _books = [];

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void RemoveBook(int id)
    {
        if (_books.Any(b => b.Id == id))
        {
            _books.Remove(_books.FirstOrDefault(b => b.Id == id));
        }
    }

    public ICollection<Book> GetBooks()
    {
        return _books;
    }

    public Book GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }
}
