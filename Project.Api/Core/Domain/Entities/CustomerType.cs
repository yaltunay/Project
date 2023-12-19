namespace Project.Api.Core.Domain.Entities;

public class CustomerType : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;

}
