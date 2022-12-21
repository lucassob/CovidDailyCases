using CovidDailyCases.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidDailyCases.Infrastructure.Data.Context
{
    public class CovidCasesDbContext : DbContext
    {
        public CovidCasesDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<CovidCases> CovidCases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
    }
}
