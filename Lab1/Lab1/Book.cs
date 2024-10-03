namespace Lab1;

public class Book(int id, string title, string author, long isbn)
{
    public int Id { get; set; } = id;
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public long ISBN { get; set; } = isbn;
}
