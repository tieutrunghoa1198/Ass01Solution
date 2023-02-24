using Microsoft.EntityFrameworkCore;
using DataAccess.DTO;

namespace DataAccess
{
    public partial class ManagementDBContext : DbContext
    {
        private static readonly string ConnectionString = @"Data Source=127.0.0.1,1433;User ID=sa;Password=123456;Database=PRN221_ASS01;Encrypt=False;Trusted_Connection=False;";
        public ManagementDBContext() { }
        public ManagementDBContext(DbContextOptions<ManagementDBContext> options) : base(options) { }
        public virtual DbSet<MemberDTO> Members { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDTO> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /**
             * Member Table
             */
            modelBuilder.Entity<MemberDTO>(entity => 
            {
                entity.ToTable("Member");
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

            /**
             * Order Table
             */
            modelBuilder.Entity<OrderDTO>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(p => p.OrderId).HasName("OrderId");
                entity.HasOne<MemberDTO>(order => order.member).WithMany(mem => mem.Orders).HasForeignKey(o => o.MemberId);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
