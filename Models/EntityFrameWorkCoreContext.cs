using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DB_First.Models;

public partial class EntityFrameWorkCoreContext : DbContext
{
    public EntityFrameWorkCoreContext()
    {
    }

    public EntityFrameWorkCoreContext(DbContextOptions<EntityFrameWorkCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<CustomerAuth> CustomerAuths { get; set; }  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configBuildern = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

        var configSection = configBuildern.GetSection("ConnectionStrings");

        var connectionString = configSection["DefaultConnection"] ?? null;

        optionsBuilder.UseSqlServer(connectionString);
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=BSD-SABARIP01\\SQLEXPRESS;Initial Catalog=EntityFrameWorkCore;Integrated Security=SSPI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8C540D537");

            entity.HasIndex(e => e.CustomerEmail, "UQ__Customer__3A0CE74C52AD3245").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetails).HasName("PK__OrderDet__62E775555F6666EA");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__OrderDeta__Custo__4E88ABD4");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__4F7CD00D");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED717A09EC");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
