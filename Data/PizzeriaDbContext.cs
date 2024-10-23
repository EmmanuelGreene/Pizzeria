using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Data.Entities;
using Pizzeria.Data.Enums;

namespace Pizzeria.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options) { }

        public DbSet<OrderEntity> Orders { get; set; }
    }
}