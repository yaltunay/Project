namespace Project.Api.Core.Domain.Entities;

public class Workplace : BaseEntity
{
    public string Name { get; set; }
    public string Representative { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Description { get; set; } = string.Empty;

    public virtual List<Estate> Estates { get; set; }
}
