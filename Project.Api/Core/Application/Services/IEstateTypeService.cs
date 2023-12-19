using Project.Api.Core.Domain.Model;

namespace Project.Api.Core.Application.Services;

public interface IEstateTypeService
{
    Task<IEnumerable<EstateTypeModel>> GetAllAsync();
    Task<EstateTypeModel> GetByIdAsync(string typeId);
    Task<EstateTypeModel> AddAsync(EstateTypeModel estateType);
}
