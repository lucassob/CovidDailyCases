using AutoMapper;
using CovidDailyCases.API.ViewModels;
using CovidDailyCases.Domain.Models;

namespace CovidDailyCases.API.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<CovidCases, CovidCasesViewModel>().ReverseMap();
    }
}
