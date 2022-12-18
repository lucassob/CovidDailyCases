using CovidDailyCases.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidDailyCases.Infrastructure.Context;

public class CovidCasesDbContext : DbContext
{
    public CovidCasesDbContext()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<CovidCases> Type { get; set; }
}