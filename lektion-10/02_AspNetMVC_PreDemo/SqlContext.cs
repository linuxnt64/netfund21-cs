using _02_AspNetMVC_PreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_AspNetMVC_PreDemo
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
