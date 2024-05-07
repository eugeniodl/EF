using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo01.Models;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    [Column("AttendanceID")]
    public int AttendanceId { get; set; }

    [Column("StudentID")]
    public int? StudentId { get; set; }

    public DateOnly Date { get; set; }

    public bool Present { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Attendances")]
    public virtual Student? Student { get; set; }
}
