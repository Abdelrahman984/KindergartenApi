using Kindergarten.Application.DTOs;

namespace Kindergarten.Application.Interfaces.Services;

public interface IReportsService
{
    Task<ReportsOverviewDto> GetOverviewAsync();
}
