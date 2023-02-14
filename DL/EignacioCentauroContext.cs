using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EignacioCentauroContext : DbContext
{
    public EignacioCentauroContext()
    {
    }

    public EignacioCentauroContext(DbContextOptions<EignacioCentauroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gpsdatum> Gpsdata { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-4F295B7J; Database= EIgnacioCentauro; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gpsdatum>(entity =>
        {
            entity.HasKey(e => e.IdGps).HasName("PK__GPSData__0C9EDE9E430B34DE");

            entity.ToTable("GPSData");

            entity.Property(e => e.DateEvent).HasColumnType("datetime");
            entity.Property(e => e.DateSystem).HasColumnType("datetime");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__ROL__2A49584C9B1A9CFA");

            entity.ToTable("ROL");

            entity.Property(e => e.RolName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PK__Users__C781FF19CC903434");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053493976935").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456E9C553F7").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Passwords).IsUnicode(false);
            entity.Property(e => e.SurName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_RolUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
