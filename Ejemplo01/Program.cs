using Ejemplo01.Data;

using (var db = new SchoolContext())
{
    var estudiantes = db.Students.ToList();
    foreach (var estudiante in estudiantes)
    {
        Console.WriteLine("Nombre: {0}", estudiante.Name);
    }
}


using(var db = new SchoolContext())
{
    Console.WriteLine("Mostrar todos los registros de la tabla Attendance");
    var asistencia = db.Attendances.ToList();
    foreach(var attendance in asistencia)
    {
        Console.WriteLine("Fecha: {0}, Estudiante: {1}, Presente: {2}", attendance.Date, 
            attendance.StudentId, attendance.Present);
    }

    // Filtro y Ordenación
    Console.WriteLine("Estudiantes registrados, ordenados alfabéticamente por su nombre");
    var registeredStudents = db.Students
        .Where(s => s.Registered == true)
        .OrderBy(s => s.Name)
        .ToList();
    foreach (var student in registeredStudents)
    {
        Console.WriteLine("Nombre: {0}", student.Name);
    }

    // Coincidencia de Patrones con LIKE
    Console.WriteLine("Estudiantes cuyo nombre comience con 'B'");
    var studentsStartingWithB = db.Students
        .Where(s => s.Name.StartsWith("B"))
        .ToList();
    foreach (var student in studentsStartingWithB)
    {
        Console.WriteLine("Nombre: {0}", student.Name);
    }
}