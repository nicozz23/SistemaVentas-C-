using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WSVENTA1.Models;

public partial class SistemaVentaContext : DbContext
{
    public SistemaVentaContext()
    {
    }

    public SistemaVentaContext(DbContextOptions<SistemaVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Concepto> Conceptos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-FL64OFQ;Database=SistemaVenta;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Concepto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Concepto");

            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.Importe).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK_Concepto_Producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany()
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK_Concepto_Ventas");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.Costo).HasColumnType("decimal(16, 2)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(16, 2)");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.Total).HasColumnType("decimal(16, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Ventas_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
