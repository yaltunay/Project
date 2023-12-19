namespace Project.Api.Core.Domain.Model;

public class EstateTypeModel : BaseModel
{

    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
