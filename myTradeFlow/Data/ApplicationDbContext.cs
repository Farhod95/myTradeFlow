using Microsoft.EntityFrameworkCore;
using myTradeFlow.Models.Brands;
using myTradeFlow.Models.Categories;

namespace myTradeFlow.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        DbSet<Category> Categories { get; set; }
        DbSet<Brand> Brands { get; set; }
    }
}
