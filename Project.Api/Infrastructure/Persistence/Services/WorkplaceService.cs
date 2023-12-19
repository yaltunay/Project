using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Infrastructure.Persistence.Services;

public class WorkplaceService : IWorkplaceService
{
    private readonly IWorkplaceRepository _workplaceRepository;

    public WorkplaceService(IWorkplaceRepository workplaceRepository)
    {
        _workplaceRepository = workplaceRepository;
    }

    public async Task<IEnumerable<WorkplaceModel>> GetAllAsync()
    {
        var workplaces = await _workplaceRepository.GetAllAsync();

        var result = workplaces
            .OrderByDescending(x => x.Name)
            .Select(x => new WorkplaceModel
            {
                Id = x.Id,
                Name = x.Name,
                Representative = x.Representative,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Mobile = x.Mobile,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted
            }).ToList();

        return result;
    }

    public async Task<WorkplaceModel> GetByIdAsync(string workplaceId)
    {
        var workplace = await _workplaceRepository.Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(workplaceId));
        return new WorkplaceModel
        {
            Id = workplace.Id,
            Name = workplace.Name,
            Representative = workplace.Representative,
            Address = workplace.Address,
            Email = workplace.Email,
            Phone = workplace.Phone,
            Mobile = workplace.Mobile,
            Description = workplace.Description,
            CreatedDate = workplace.CreatedDate,
            UpdatedDate = workplace.UpdatedDate,
            IsActive = workplace.IsActive,
            IsDeleted = workplace.IsDeleted
        };
    }

    public async Task<WorkplaceModel> AddAsync(WorkplaceModel workplace)
    {
        var entity = new Workplace
        {
            Name = workplace.Name,
            Representative = workplace.Representative,
            Address = workplace.Address,
            Email = workplace.Email,
            Phone = workplace.Phone,
            Mobile = workplace.Mobile,
            Description = workplace.Description
        };

        var result = await _workplaceRepository.AddAsync(entity);

        return new()
        {
            Id = result.Id,
            Name = result.Name,
            Representative = result.Representative,
            Address = result.Address,
            Email = result.Email,
            Phone = result.Phone,
            Mobile = result.Mobile,
            Description = result.Description,
            CreatedDate = result.CreatedDate,
            UpdatedDate = result.UpdatedDate,
            IsActive = result.IsActive,
            IsDeleted = result.IsDeleted
        };
    }

    
}
