using API1.Entitis;
using Microsoft.EntityFrameworkCore;

namespace API1.Data
{
    public class DBCotext : DbContext
    {
        public DBCotext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<User> users { get; set; }
    }
}
