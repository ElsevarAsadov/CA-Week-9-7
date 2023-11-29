using AllUpHomeWork.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;


namespace AllUpHomeWork.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductModel> products { get; set; }
        public DbSet<ColorModel> colors { get; set; }
        public DbSet<SizeModel> sizes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
