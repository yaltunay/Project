namespace Project.Api.Core.Domain.Model;

public class CustomerModel : BaseModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid CustomerTypeId { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
}
