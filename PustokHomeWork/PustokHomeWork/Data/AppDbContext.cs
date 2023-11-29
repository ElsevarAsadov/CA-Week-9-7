using Microsoft.EntityFrameworkCore;
using PustokHomeWork.Models;

namespace PustokHomeWork.Data;

public class AppDbContext : DbContext
{

    public DbSet<BookModel> Books { get; set; }
    public DbSet<AuthorModel> Authors { get; set; }
    public DbSet<TagModel> Tags { get; set; }

    //no need pivot one

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}