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

    Console.WriteLine("Estudiantes cuyo nombre contenga 'a' " +
        "ordenados alfabéticamente por su nombre");
    var studentsWithAInName = db.Students
        .Where(s => s.Name.Contains("a"))
        .OrderBy(s => s.Name)
        .ToList();
    foreach (var student in studentsWithAInName)
    {
        Console.WriteLine("Nombre: {0}", student.Name);
    }
    // Filtros Globales
    Console.WriteLine("Obtener los estudiantes que hayan asistido el día de hoy, " +
        "ordenados por su ID de asistencia (AttendanceID)");
    var studentsPresentToday = db.GetPresentStudents()
             .Where(a => a.Date == DateOnly.FromDateTime(DateTime.Today))
             .OrderBy(a => a.AttendanceId)
             .ToList();
    foreach (var item in studentsPresentToday)
    {
        Console.WriteLine($"{item.Student.Name}");
    }

    Console.WriteLine("Mostrar los detalles de las asistencias " +
        "(AttendanceID, StudentID, Date, Present) " +
        "junto con los nombres de los estudiantes " +
        "correspondientes de la tabla Attendance y Students respectivamente");
    var attendanceDetailsWithStudentNames = db.Attendances
        .Select(a => new
        {
            a.AttendanceId,
            a.StudentId,
            a.Date,
            a.Present,
            StudentName = a.Student.Name
        }).ToList();
    foreach (var item in attendanceDetailsWithStudentNames)
    {
        Console.WriteLine($"{item.AttendanceId} " +
            $"{item.StudentId} " +
            $"{item.Date} " +
            $"{item.Present} " +
            $"{item.StudentName}");
    }
    Console.WriteLine("Obtener todos los estudiantes " +
        "junto con el número total de asistencias que han registrado cada uno");

}