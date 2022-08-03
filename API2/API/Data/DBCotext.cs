using System;
using Microsoft.EntityFrameworkCore;

namespace API2.Data
{
    public class DBCotext : DbContext
    {
        public DBCotext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<API2.Entities.Cotacts> Contacts { get; set; }
    }
}