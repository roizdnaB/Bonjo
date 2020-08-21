using BonjoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BonjoAPI.Others
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data source=data.db;");
        }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<MovieDTO> Movies { get; set; }
    }
}