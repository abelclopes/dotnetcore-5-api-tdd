using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Model;
using Microsoft.EntityFrameworkCore;

namespace infra.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("user")
                .HasKey(k => k.Id);

                e.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
