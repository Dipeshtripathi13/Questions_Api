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
//define datacontext class which is subclass of dbcontext form microsoft entity framework core library. userd for connecting to a database and managing database entities
//the DataContext constructor takes an argument options of type dbcontextoptions, used to configure the context with the necessary database provider and connection string
//The questions properties in a dbset represent collection of question_entity objects that can be queried, added, updated and deleted from database
