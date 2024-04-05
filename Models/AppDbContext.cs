using Microsoft.EntityFrameworkCore;
using WebAppMVC_1.Models.Contact;
namespace WebAppMVC_1.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }
    }
}
