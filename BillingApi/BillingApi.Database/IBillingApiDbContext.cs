using BillingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace BillingApi.Database
{
    public interface IBillingApiDbContext
    {
        DbSet<T> Set<T>() where T : class;

        EntityEntry<T> Entry<T>(T entity) where T : class;

        public DbSet<Order> Orders { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        Task<int> SaveChangesAsync();

        int SaveChanges();
    }
}
