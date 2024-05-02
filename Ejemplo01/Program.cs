using Ejemplo01.Models;
using Microsoft.EntityFrameworkCore;

using (var db = new SchoolContext())
{
    var estudiantes = db.Students.ToList();
    foreach (var estudiante in estudiantes)
    {
        Console.WriteLine("Nombre: {0}", estudiante.Name);
    }
}
