using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vinapp.Data.Models;

namespace Vinapp.Data
{
    public class VinappContext : IdentityDbContext
    {
        public VinappContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        private IConfiguration _config;

        public DbSet<LotteryTicket> LotteryTickets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LotteryTicket>()
                .Property(p => p.Week);

            builder.Entity<LotteryTicket>()
                .Property(p => p.RowVersion)
                .ValueGeneratedOnAddOrUpdate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["Data:ConnectionString"]);
        }
    }
}
