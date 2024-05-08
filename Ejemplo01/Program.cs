
using Ejemplo01.Data;
using Ejemplo01.Models;
using System.Text.RegularExpressions;

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
    var studentsPresentToday = db.GetPresentStudents()
        .Where(a => a.Date == DateOnly.FromDateTime(DateTime.Today))
        .OrderBy(a => a.AttendanceId)
        .ToList();

    foreach (var item in studentsPresentToday)
    {
        Console.WriteLine($"{item.Student.Name}");
    }

    Console.WriteLine("Mostrar los detalles de las asistencias " +
        "(AttendaceID, StudentID, Date, Present) " +
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

    Console.WriteLine("Encontrar el día con la mayor cantidad de asistencias");
    var dayWithMostAttendance = db.GetPresentStudents().GroupBy(a => a.Date)
        .OrderByDescending(g => g.Count())
        .Select(g => g.Key)
        .FirstOrDefault();

    Console.WriteLine(dayWithMostAttendance);

    Console.WriteLine("Obtener todos los estudiantes " +
        "junto con el número de asistencias que han registrado cada uno");
    var studentsWithTotalAttendance =
        db.GetPresentStudents()
        .GroupBy(a => a.Student)
        .Select(g => new
        {
            Estudiante = g.Key.Name,
            Asistencia = g.Count()
        }).ToList();

    foreach( var item in studentsWithTotalAttendance)
    {
        Console.WriteLine($"{item.Estudiante} {item.Asistencia}");
    }
}