using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasketballStore.Models;

namespace BasketballStore.Data
{
    public class BasketballStoreContext : DbContext
    {
        public BasketballStoreContext (DbContextOptions<BasketballStoreContext> options)
            : base(options)
        {
        }

        public DbSet<BasketballStore.Models.Merch> Merch { get; set; } = default!;
    }
}
