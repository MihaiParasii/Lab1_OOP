using Lab1;

var book1  = new Book(1, "Book 1", "Book 1", 123123123);
var book2  = new Book(1, "Book 2", "Book 2", 123123123);
var book3  = new Book(1, "Book 3", "Book 3", 123123123);
var book4  = new Book(1, "Book 4", "Book 4", 123123123);



var library = new Library();
library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);
library.AddBook(book4);

var books = library.GetBooks();

foreach (var book in books)
{
    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
}