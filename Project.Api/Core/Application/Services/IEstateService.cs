using Project.Api.Core.Domain.Model;

namespace Project.Api.Core.Application.Services;

public interface IEstateService
{
    Task<IEnumerable<EstateModel>> GetAllAsync();
    Task<EstateModel> GetByIdAsync(string estateId);
    Task<EstateModel> AddAsync(EstateModel estate);
}
