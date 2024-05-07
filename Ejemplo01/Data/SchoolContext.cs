using System;
using System.Collections.Generic;
using System.Configuration;
using Ejemplo01.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo01.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public IQueryable<Student> GetRegisteredStudents()
        => Students.Where(s => s.Registered == true);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conexion = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        optionsBuilder.UseSqlServer(conexion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263CE21ECE72");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Suden__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
