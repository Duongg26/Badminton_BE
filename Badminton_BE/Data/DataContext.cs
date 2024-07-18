using Badminton_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Badminton_BE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

       public DbSet<Account> Accounts { get; set; }
        public DbSet<Yard> Yards { get; set; }
        public DbSet<ReviewYard> Reviews { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
