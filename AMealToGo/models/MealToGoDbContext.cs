using Microsoft.EntityFrameworkCore;
using AMealToGo.models;

namespace AMealToGo.models
{
    public class MealToGoDbContext : DbContext 
    {
        public MealToGoDbContext(DbContextOptions<MealToGoDbContext> options) :base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AMealToGo.models.Product> Product { get; set; } = default!;
        public DbSet<Customer> Customer {  get; set; }
    }
}