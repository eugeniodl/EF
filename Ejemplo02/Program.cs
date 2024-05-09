using Ejemplo02.Data;
using Ejemplo02.Models;

using (var db = new LibraryContext())
{
    // Crear autores
    /*var author1 = new Author { Name = "Stephen King" };
    var author2 = new Author { Name = "J.K. Rowling" };
    db.Authors.Add(author1);
    db.Authors.Add(author2);
    db.SaveChanges();
    Console.WriteLine("Autores agregados correctamente");
    // Crear libros
    var book1 = new Book { Title = "IT", AuthorId = 1};
    var book2 = new Book 
    { 
        Title = "Harry Potter and the Philosopher's Stone", 
        AuthorId = 2
    };
    db.Books.AddRange(book1, book2);
    db.SaveChanges();
    Console.WriteLine("Libros agregados correctamente");*/

    // Actualización de entidades
    var authorToUpdate = db.Authors.Find(2);
    if(authorToUpdate != null )
    {
        authorToUpdate.Name = "Rubén Darío";
        db.SaveChanges();
    }

    // Eliminación de entidades
    var bookToDelete = db.Books.Find(2);
    if( bookToDelete != null )
    {
        db.Books.Remove(bookToDelete);
        db.SaveChanges();
    }

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
    foreach(var author in authors)
    {
        Console.WriteLine($"Nombre: {author.Name}");
    }
}