using Microsoft.EntityFrameworkCore;
using MpesaDarajaAPI.Models;


namespace MpesaDarajaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<MpesaTransaction> MpesaTransactions{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
       
}
}
