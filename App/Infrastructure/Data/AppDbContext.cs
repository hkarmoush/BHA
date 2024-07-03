using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Kpi> Kpis { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<FinancialRecord> FinancialRecords { get; set; }
        public DbSet<HRRecord> HRRecords { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // User
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Role).HasConversion<string>();

            // KPIs
            modelBuilder.Entity<Kpi>().HasKey(k => k.Id);
            modelBuilder.Entity<Kpi>().Property(k => k.Role).HasConversion<string>();

            // Records
            modelBuilder.Entity<SalesRecord>().HasKey(sr => sr.Id);
            modelBuilder.Entity<FinancialRecord>().HasKey(fr => fr.Id);
            modelBuilder.Entity<HRRecord>().HasKey(hr => hr.Id);
        }
    }
}