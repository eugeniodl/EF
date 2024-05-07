
using Ejemplo01.Data;

using (var db = new SchoolContext())
{
    var students = db.Students.ToList();

    foreach (var student in students)
    {
        Console.WriteLine($"Nombre = {student.Name}, " +
            $"Registrado = {student.Registered}");
    }

    var attendance = db.Attendances.ToList();

    foreach (var item in attendance)
    {
        Console.WriteLine("Fecha: {0}, Estudiante: {1}, Asistió: {2}",
            item.Date, item.StudentId, item.Present);
    }

    // Filtro y ordenación
    Console.WriteLine("Estudiantes registrados, " +
        "ordenados alfabéticamente por su nombre");

    var registeredStudents = db.Students
                              .Where(s => s.Registered)
                              .OrderBy(s => s.Name)
                              .ToList();
    foreach(var student in registeredStudents)
    {
        Console.WriteLine($"{student.Name}");
    }

    // Coincidencia de patrones con LIKE
    Console.WriteLine("Estudiantes cuyo nombre comience con 'B'");

    var studentsStartingWithB = db.Students
                                 .Where(s => s.Name.StartsWith("B"))
                                 .ToList();

    foreach (var student in studentsStartingWithB)
    {
        Console.WriteLine($"{student.Name}");
    }

    // Filtro Globales
    registeredStudents = db.GetRegisteredStudents().ToList();
    Console.WriteLine("Estudiantes cuyo nombre comience con 'B'");
    studentsStartingWithB = db.GetRegisteredStudents()
                             .Where(s => s.Name.StartsWith("B"))
                             .ToList();

    foreach (var student in studentsStartingWithB)
    {
        Console.WriteLine($"{student.Name}");
    }

    Console.WriteLine("Estudiantes cuyo nombre contenga 'a' " +
        "ordenados alfabéticamente por su nombre");
    var studentWithAInName = db.GetRegisteredStudents()
                              .Where(s => s.Name.Contains("a"))
                              .OrderBy(s => s.Name)
                              .ToList();
    foreach (var student in studentWithAInName)
    {
        Console.WriteLine($"{student.Name}");
    }

    Console.WriteLine("Obtener los estudiantes que hayan asistido el día de hoy," +
        "ordenados por su ID de asistencia (AttendanceID)");

}