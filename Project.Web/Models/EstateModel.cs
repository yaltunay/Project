namespace Project.Web.Models;

public class EstateModel : BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Square { get; set; }
    public short RoomCount { get; set; }
    public short FloorCount { get; set; }
    public short Floor { get; set; }
    public Guid EstateTypeId { get; set; }
    public Guid CustomerId { get; set; }
}
