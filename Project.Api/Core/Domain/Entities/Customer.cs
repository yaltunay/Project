namespace Project.Api.Core.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Guid CustomerTypeId { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }


    public virtual List<Estate> Estates { get; set; }
    public virtual CustomerType CustomerType { get; set; }
}
