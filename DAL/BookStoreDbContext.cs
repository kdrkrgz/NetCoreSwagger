using Microsoft.EntityFrameworkCore;
using NetCoreSwagger.Models;

namespace NetCoreSwagger.DAL
{
    public class BookStoreDbContext: DbContext
    {
        public BookStoreDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        
    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Author>()
        .HasMany(a => a.Books)
        .WithOne(b => b.Author)
        .OnDelete(DeleteBehavior.SetNull);
    }
    }

}