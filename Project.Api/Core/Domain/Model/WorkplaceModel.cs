namespace Project.Api.Core.Domain.Model;

public class WorkplaceModel : BaseModel
{
    public string Name { get; set; }
    // Yetkili
    public string Representative { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }    = string.Empty;
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Description { get; set; } = string.Empty;
}
