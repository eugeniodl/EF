using Ejemplo01.Models;

using (var db = new SchoolContext())
{
    var students = db.Students.ToList();

    foreach (var student in students)
    {
        Console.WriteLine($"Nombre = {student.Name}, " +
            $"Registered = {student.Registered}");
    }
}