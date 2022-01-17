using AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVC
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }
    }
}
