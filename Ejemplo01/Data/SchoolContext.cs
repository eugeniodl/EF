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
        => Students.Where(s => s.Registered);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection =
            ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263CE73E4380");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Stude__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
