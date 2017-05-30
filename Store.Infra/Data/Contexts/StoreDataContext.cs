using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Infra.Data.Contexts
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext(DbContextOptions<StoreDataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}