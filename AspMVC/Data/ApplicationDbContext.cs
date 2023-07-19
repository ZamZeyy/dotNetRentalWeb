
using AspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
               
        }
        public DbSet<CarViewModel> Rentals { get; set; }
    }
}
