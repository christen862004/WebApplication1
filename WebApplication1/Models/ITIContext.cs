using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Assiut_SignalRIntake44;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product() {Id=1,Name="Iphone",Description="DEs1",Price=123000 });
            modelBuilder.Entity<Product>().HasData(new Product() { Id = 2, Name = "Samsung", Description = "DEs1", Price = 12000 });

            modelBuilder.Entity<Product>().HasData(new Product() { Id = 3, Name = "Lg", Description = "DEs1", Price = 23000 });

            modelBuilder.Entity<Product>().HasData(new Product() { Id = 4, Name = "Nokia", Description = "DEs1", Price = 3000 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
