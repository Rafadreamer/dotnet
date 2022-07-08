using Microsoft.EntityFrameworkCore;

namespace trabalhoaula
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            :base(opts)
        {}
        public DbSet<Person> People {get; set; }

        public DbSet<City> Cities {get; set; }
        public DbSet<Billing> Billings {get; set; }
        
    }
}
