using Loyality.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loyality.DbContextApplication
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<RiderData> riders { get; set; }


    }
}
