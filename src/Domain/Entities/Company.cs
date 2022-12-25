using Domain.Common;

namespace Domain.Entities
{
    public class Company : BaseAuditableEntity
    {
        required public string Name { get; set; }
        required public Person Statutory { get; set; }
    }
}