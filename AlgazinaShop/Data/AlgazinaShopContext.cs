using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlgazinaShop.Data;

public partial class AlgazinaShopContext : DbContext
{
    public AlgazinaShopContext()
    {
    }

    public AlgazinaShopContext(DbContextOptions<AlgazinaShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //Data Source=.\\SQLEXPRESS;Initial Catalog=AlgazinaShop;Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=true; Encrypt=false;

    //Data Source=server46;Initial Catalog=AlgazinaShop;Persist Security Info=True;User ID=stud;Password=stud; TrustServerCertificate=true;

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //        => optionsBuilder.UseSqlServer("Data Source=server46;Initial Catalog=AlgazinaShop;Persist Security Info=True;User ID=stud;Password=stud; TrustServerCertificate=true; ");
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
=> optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=AlgazinaShop;Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=true; Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.FullFrame)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Lens)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TypeOfFocalLength).HasMaxLength(50);
            entity.Property(e => e.WaterResistance)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
