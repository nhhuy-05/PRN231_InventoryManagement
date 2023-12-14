using API_InventoryManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API_InventoryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<Input> Inputs { get; set; } = null!;
        public virtual DbSet<InputDetail> InputDetails { get; set; } = null!;
        public virtual DbSet<Output> Outputs { get; set; } = null!;
        public virtual DbSet<OutputDetail> OutputDetails { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.Property(e => e.CategoryName).IsRequired();
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.Property(e => e.ProductName).IsRequired();
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitId);
                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId);
            });

            builder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers");
                entity.Property(e => e.SupplierName).IsRequired();
                entity.Property(e => e.Address).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Phone).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Email).HasColumnType("nvarchar(max)");
                entity.Property(e => e.ContractDate).HasColumnType("datetime");
            });

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.Property(e => e.CustomerName).IsRequired();
                entity.Property(e => e.Address).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Phone).HasColumnType("nvarchar(max)");
                entity.Property(e => e.Email).HasColumnType("nvarchar(max)");
                entity.Property(e => e.ContractDate).HasColumnType("datetime");
            });

            builder.Entity<Unit>(entity =>
            {
                entity.ToTable("Units");
                entity.Property(e => e.UnitName).IsRequired();
            });

            builder.Entity<Input>(entity =>
            {
                entity.ToTable("Inputs");
                entity.Property(e => e.Id).HasColumnType("nvarchar(450)");
                entity.Property(e => e.InputDate).HasColumnType("datetime");
                entity.Property(e => e.Note).HasColumnType("nvarchar(max)");
                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Inputs)
                    .HasForeignKey(d => d.SupplierId);
                // TODO: relationship one to many with IdentityUser
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Inputs)
                    .HasForeignKey(d => d.StaffId);
            });

            builder.Entity<InputDetail>(entity =>
            {
                entity.ToTable("InputDetails");
                // set primary key
                entity.HasKey(e => new { e.InputId, e.ProductId });
                entity.Property(e => e.Quantity).HasColumnType("int").IsRequired();
                entity.Property(e => e.InputPrice).HasColumnType("decimal(18,2)");
                entity.HasOne(d => d.Input)
                    .WithMany(p => p.InputDetails)
                    .HasForeignKey(d => d.InputId);
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InputDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            builder.Entity<Output>(entity =>
            {
                entity.ToTable("Outputs");
                entity.Property(e => e.Id).HasColumnType("nvarchar(450)");
                entity.Property(e => e.OutputDate).HasColumnType("datetime");
                entity.Property(e => e.Note).HasColumnType("nvarchar(max)");
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.CustomerId);
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.StaffId);
            });

            builder.Entity<OutputDetail>(entity =>
            {
                entity.ToTable("OutputDetails");
                // set primary key
                entity.HasKey(e => new { e.OutputId, e.ProductId , e.InputId});
                entity.Property(e => e.Quantity).HasColumnType("int").IsRequired();
                entity.Property(e => e.OutputPrice).HasColumnType("decimal(18,2)");
                entity.HasOne(d => d.Output)
                    .WithMany(p => p.OutputDetails)
                    .HasForeignKey(d => d.OutputId);
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OutputDetails)
                    .HasForeignKey(d => d.ProductId);
            });
        }


    }
}
