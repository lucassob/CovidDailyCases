using AutoMapper;
using CovidDailyCases.API.ViewModels;
using CovidDailyCases.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidDailyCases.API.Controllers;

[Route("api/cases")]
[ApiController]
public class CasesController : ControllerBase
{
    private readonly ICovidCasesRepository _covidCasesRepository;
    private readonly IMapper _mapper;

    public CasesController(ICovidCasesRepository covidCasesRepository, IMapper mapper)
    {
        _covidCasesRepository = covidCasesRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetMessage()
    {
        return Ok("ullstack Challenge 2021 🏅 - Covid Daily Cases");
    }

    [HttpGet]
	[Route("dates")]
	public async Task<IActionResult> GetDates()
	{
		return Ok(await _covidCasesRepository.GetAllDates());
	}

    [HttpGet]
    [Route("{date}/count")]
    public async Task<IActionResult> GetByDayGroupByCountryCount(DateOnly date)
    {
        var viewModel = _mapper.Map<IEnumerable<CovidCasesViewModel>>(
            await _covidCasesRepository.GetByDayGroupByCountryCount(date));
        return Ok(viewModel);
    }

    [HttpGet]
    [Route("{date}/count/cumulative")]
    public async Task<IActionResult> GetSumByDateRangeGroupByCountry(DateOnly date)
    {
        var viewModel = _mapper.Map<IEnumerable<CovidCasesViewModel>>(
            await _covidCasesRepository.GetSumByDateRangeGroupByCountry(date));
        return Ok(viewModel);
    }
}
