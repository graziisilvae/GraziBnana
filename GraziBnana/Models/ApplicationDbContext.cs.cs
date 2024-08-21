using Microsoft.EntityFrameworkCore;

namespace GraziBnana.Models
{
    public class ApplicationDbContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
            options) : base(options)
            {
            }
            public DbSet<Student> Students { get; set; }
            internal bool TestConnection()
            {
                throw new NotImplementedException();
            }
        }
    }
}
}
