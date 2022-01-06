using Microsoft.EntityFrameworkCore;
using PAndCVeterinary.Models;

namespace PAndCVeterinary.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Appointment> Appointment { get; set; }
    }
}
