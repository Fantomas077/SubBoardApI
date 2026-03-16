using Microsoft.EntityFrameworkCore;
using SubBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubBoard.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Category { get; set; }
    }
}
