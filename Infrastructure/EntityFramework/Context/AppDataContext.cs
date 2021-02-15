using Domain;
using Infrastructure.EntityFramework.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    public class AppDataContext : IdentityDbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }
        public AppDataContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
        }
    }
}