using CovidDailyCases.Domain.Models;

namespace CovidDailyCases.Domain.Interfaces
{
    public interface ICovidCasesRepository : IRepository<CovidCases>
    {
        Task<IEnumerable<DateOnly>> GetAllDates();
        Task<IEnumerable<CovidCases>> GetByDayGroupByCountryCount(DateOnly date);
        Task<IEnumerable<CovidCases>> GetSumByDateRangeGroupByCountry(DateOnly date);
    }
}
