using Ejemplo02.Data;
using Ejemplo02.Models;

using (var db = new LibraryContext())
{
    // Crear autores y libros
    /*var author1 = new Author { Name = "Stephen King" };
    var author2 = new Author { Name = "J.K. Rowling" };
    db.Authors.AddRange(author1, author2);
    db.SaveChanges();

    var book1 = new Book { Title = "IT", AuthorId = 1 };
    var book2 = new Book { Title = "Harry Potter and the Philopher's Stone", AuthorId = 2 };
    db.Books.AddRange(book1, book2);
    db.SaveChanges();*/

    // Consultar libros y autores
    var books = db.Books.ToList();
    var authors = db.Authors.ToList();

    // Mostrar resultados
    Console.WriteLine("Libros:");
    foreach (var book in books)
    {
        Console.WriteLine($"Título: {book.Title}, Autor: {book.Author.Name}");
    }

    Console.WriteLine("\nAutores");
    foreach (var author in authors)
    {
        Console.WriteLine($"Nombre: {author.Name}");
    }
}
