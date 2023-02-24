using Microsoft.EntityFrameworkCore;
using DataAccess.DTO;

namespace DataAccess
{
    public partial class ManagementDBContext : DbContext
    {
        public ManagementDBContext() { }
        public ManagementDBContext(DbContextOptions<ManagementDBContext> options) : base(options) { }
        public virtual DbSet<MemberDTO> Members { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;User ID=sa;Password=123456;Database=PRN221_ASS01;Encrypt=False;Trusted_Connection=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**
             * Member Table
             */
            modelBuilder.Entity<MemberDTO>(entity => 
            {
                entity.ToTable("MemberDTO");
                entity.HasKey(p => p.MemberId).HasName("MemberId");
                
            });

            /**
             * Product Table
             */
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.ProductId).HasName("ProductId");
            });

            //modelBuilder.Entity<Order>(entity =>
            //{
            //    entity.Property(e => e.ProductId)
            //        .ValueGeneratedNever()
            //        .HasColumnName("ProductId");
            //    entity.Property(e => e.CategoryId)
            //        .HasColumnName("CategoryId");
            //    entity.Property(e => e.ProductName)
            //        .HasColumnName("ProductName");
            //    entity.Property(e => e.Weight)
            //        .HasColumnName("Weight");
            //    entity.Property(e => e.UnitPrice)
            //        .HasColumnName("UnitPrice");
            //    entity.Property(e => e.UnitInStock)
            //        .HasColumnName("UnitInStock");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
