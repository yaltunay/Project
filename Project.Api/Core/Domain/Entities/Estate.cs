namespace Project.Api.Core.Domain.Entities;

public class Estate : BaseEntity
{
    public string Name { get; set; }
    public double Square { get; set; }
    public short RoomCount { get; set; }
    public short FloorCount { get; set; }
    public short Floor { get; set; }
    public Guid EstateTypeId { get; set; }
    public Guid CustomerId { get; set; }

    public virtual EstateType EstateType { get; set; }
    public virtual Customer Customer { get; set; }
}
