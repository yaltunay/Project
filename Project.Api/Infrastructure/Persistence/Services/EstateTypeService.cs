

using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Infrastructure.Persistence.Services;

public class EstateTypeService: IEstateTypeService
{
    private readonly IEstateTypeRepository _estateTypeRepository;

    public EstateTypeService(IEstateTypeRepository estateTypeRepository)
    {
        _estateTypeRepository = estateTypeRepository;
    }


    public async Task<IEnumerable<EstateTypeModel>> GetAllAsync()
    {
        var estateTypes = await _estateTypeRepository.GetAllAsync();

        var result = estateTypes
            .OrderByDescending(x => x.Name)
            .Select(x => new EstateTypeModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description
        }).ToList();

        return result;
    }

    public async Task<EstateTypeModel> GetByIdAsync(string typeId)
    {
        var estateType = await _estateTypeRepository.Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(typeId));
        return new()
        {
            Id = estateType.Id,
            Name = estateType.Name,
            Description = estateType.Description
        };
    }

    public async Task<EstateTypeModel> AddAsync(EstateTypeModel estateType)
    {
        var entity = new EstateType
        {
            Name = estateType.Name,
            Description = estateType.Description
        };

        var result = await _estateTypeRepository.AddAsync(entity);

        return new()
        {
            Id = result.Id,
            Name = result.Name,
            Description = result.Description
        };
    }
}
