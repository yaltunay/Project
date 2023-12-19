using Project.Api.Core.Domain.Model;

namespace Project.Api.Core.Application.Services;

public interface IWorkplaceService
{
    Task<IEnumerable<WorkplaceModel>> GetAllAsync();
    Task<WorkplaceModel> GetByIdAsync(string workplaceId);
    Task<WorkplaceModel> AddAsync(WorkplaceModel workplace);
}
