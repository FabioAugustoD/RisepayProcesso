using Microsoft.EntityFrameworkCore;
using Risepay.Domain.Entities;
using System.Diagnostics;


namespace Risepay.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "ConnectionStrings:Database",
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly("Risepay.Infra"));
            }
        }
       
    }
}
