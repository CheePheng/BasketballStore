using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasketballStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BasketballStore.Data
{
    public class BasketballStoreContext : IdentityDbContext<BasketballStoreUser>
    {
        public BasketballStoreContext(DbContextOptions<BasketballStoreContext> options)
            : base(options)
        {
        }

        public DbSet<BasketballStore.Models.TeamName> TeamName { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TeamName>().HasData(
                new TeamName
                {
                    TeamNameId = 1,
                    Name = "Los Angeles Lakers"
                },
                new TeamName
                {
                    TeamNameId = 2,
                    Name = "LA Clippers"
                }
            );
        }
    }
}






