using System;
using System.Collections.Generic;

namespace Ejemplo01.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public bool Registered { get; set; }
}
