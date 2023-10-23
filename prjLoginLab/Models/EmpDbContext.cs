using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjLoginLab.Models;

public partial class EmpDbContext : DbContext
{
    public EmpDbContext()
    {
    }

    public EmpDbContext(DbContextOptions<EmpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TEmployee> TEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\N000190143\\Documents\\slnLoginLab\\prjLoginLab\\App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TEmployee>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tEmploye__D9F8227CA31D084C");

            entity.ToTable("tEmployee");

            entity.Property(e => e.FId)
                .HasMaxLength(50)
                .HasColumnName("fId");
            entity.Property(e => e.FEployeeDate)
                .HasColumnType("date")
                .HasColumnName("fEployeeDate");
            entity.Property(e => e.FGender)
                .HasMaxLength(50)
                .HasColumnName("fGender");
            entity.Property(e => e.FMail)
                .HasMaxLength(50)
                .HasColumnName("fMail");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("fName");
            entity.Property(e => e.FPwd)
                .HasMaxLength(50)
                .HasColumnName("fPwd");
            entity.Property(e => e.FRole)
                .HasMaxLength(50)
                .HasColumnName("fRole");
            entity.Property(e => e.FSalary).HasColumnName("fSalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
