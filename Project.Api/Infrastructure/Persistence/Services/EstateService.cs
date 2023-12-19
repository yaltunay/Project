using Microsoft.EntityFrameworkCore;
using Project.Api.Core.Application.Repositories;
using Project.Api.Core.Application.Services;
using Project.Api.Core.Domain.Entities;
using Project.Api.Core.Domain.Model;

namespace Project.Api.Infrastructure.Persistence.Services;

public class EstateService : IEstateService
{
    private readonly IEstateRepository _estateRepository;

    public EstateService(IEstateRepository estateRepository)
    {
        _estateRepository = estateRepository;
    }

    public async Task<IEnumerable<EstateModel>> GetAllAsync()
    {
        var estates = await _estateRepository.GetAllAsync();

        var result = estates
            .OrderByDescending(x => x.Name)
            .Select(x => new EstateModel
            {
                Id = x.Id,
                Name = x.Name,
                FloorCount = x.FloorCount,
                Floor = x.Floor,
                EstateTypeId = x.EstateTypeId,
                CustomerId = x.CustomerId,
                Square = x.Square,
                RoomCount = x.RoomCount,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate
            }).ToList();

        return result;
    }

    public async Task<EstateModel> GetByIdAsync(string typeId)
    {
        var estate = await _estateRepository.Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(typeId));
        return new EstateModel
        {
            Id = estate.Id,
            Name = estate.Name,
            FloorCount = estate.FloorCount,
            Floor = estate.Floor,
            EstateTypeId = estate.EstateTypeId,
            CustomerId = estate.CustomerId,
            Square = estate.Square,
            RoomCount = estate.RoomCount,
            CreatedDate = estate.CreatedDate,
            UpdatedDate = estate.UpdatedDate
        };
    }

    public async Task<EstateModel> AddAsync(EstateModel estate)
    {
        var entity = new Estate
        {
            Name = estate.Name,
            FloorCount = estate.FloorCount,
            Floor = estate.Floor,
            EstateTypeId = estate.EstateTypeId,
            CustomerId = estate.CustomerId,
            Square = estate.Square,
            RoomCount = estate.RoomCount
        };

        var result = await _estateRepository.AddAsync(entity);

        return new()
        {
            Id = estate.Id,
            Name = estate.Name,
            FloorCount = estate.FloorCount,
            Floor = estate.Floor,
            EstateTypeId = estate.EstateTypeId,
            CustomerId = estate.CustomerId,
            Square = estate.Square,
            RoomCount = estate.RoomCount,
            CreatedDate = estate.CreatedDate,
            UpdatedDate = estate.UpdatedDate
        };
    }
}
