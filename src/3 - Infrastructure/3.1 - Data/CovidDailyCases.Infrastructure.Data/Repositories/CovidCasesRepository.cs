
using CovidDailyCases.Domain.Interfaces;
using CovidDailyCases.Domain.Models;
using CovidDailyCases.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CovidDailyCases.Infrastructure.Data.Repositories
{
    public class CovidCasesRepository : Repository<CovidCases>, ICovidCasesRepository
    {
        public CovidCasesRepository(CovidCasesDbContext context) : base(context) { }

        public async Task<IEnumerable<DateOnly>> GetAllDates()
        {
            return await Db.CovidCases.AsNoTracking().Select(d => d.Date).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<CovidCases>> GetByDayGroupByCountryCount(DateOnly date)
        {
            return await Db.CovidCases.AsNoTracking()
                .Where(w => w.Date == date)
                .GroupBy(g => g.Location)
                .Select(s => new CovidCases
                {
                    Location = s.First().Location,
                    Date = s.First().Date,
                    Variant = s.First().Variant,
                    NumSequences = s.Sum(o => o.NumSequences),
                    PercSequences = s.Sum(o => o.PercSequences),
                    NumSequencesTotal = s.Sum(o => o.NumSequencesTotal)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CovidCases>> GetSumByDateRangeGroupByCountry(DateOnly date)
        {
            return await Db.CovidCases.AsNoTracking()
                .Where(w => w.Date <= date)
                .GroupBy(g => g.Location)
                .Select(s => new CovidCases
                {
                    Location = s.First().Location,
                    Date = s.First().Date,
                    Variant = s.First().Variant,
                    NumSequences = s.Sum(o => o.NumSequences),
                    PercSequences = s.Sum(o => o.PercSequences),
                    NumSequencesTotal = s.Sum(o => o.NumSequencesTotal)
                })
                .ToListAsync();
        }
    }
}
