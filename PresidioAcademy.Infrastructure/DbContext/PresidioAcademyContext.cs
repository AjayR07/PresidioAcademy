using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PresidioAcademy.Domain.Models;
using PresidioAcademy.Infrastructure;

namespace PresidioAcademy.Infrastructure.DbContext;

public partial class PresidioAcademyContext : Microsoft.EntityFrameworkCore.DbContext, IPresidioAcademyContext
{
    public PresidioAcademyContext(DbContextOptions<PresidioAcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.MacAddress).HasName("PK__Asset__50EDF1CCB4373336");

            entity.ToTable("Asset");

            entity.HasIndex(e => e.SerialNo, "UQ__Asset__5E5A535E7F19BF8C").IsUnique();

            entity.Property(e => e.MacAddress)
                .HasMaxLength(17)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ModelName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Os)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OS");
            entity.Property(e => e.SerialNo)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Assets)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Employee");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC272E390642");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D105346486E244").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
