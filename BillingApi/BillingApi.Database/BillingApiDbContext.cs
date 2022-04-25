using Microsoft.EntityFrameworkCore;
using BillingApi.Models;
using System.Threading.Tasks;

namespace BillingApi.Database
{
    public class BillingApiDbContext : DbContext, IBillingApiDbContext
    {
        public BillingApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
