using Microsoft.EntityFrameworkCore;
using Questions_Api.Models;

namespace Questions_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Question_Entity> Questions { get; set; }
    }
}
