using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }

        // This DbSet contains "Review" objects and is called "AllReviews"
        public DbSet<Review> reviews { get; set; }
    }
}