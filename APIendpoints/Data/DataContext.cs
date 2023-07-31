using APIendpoints.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIendpoints.Data
{
    public class DataContext : DbContext
    {
        private readonly DbContextOptions _options;

        public DataContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public virtual DbSet<Brand> Brand { get; set; }
    }
}
