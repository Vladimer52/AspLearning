using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Models
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated(); //создаем базу данных, если она еще не создана
        }
    }
}
