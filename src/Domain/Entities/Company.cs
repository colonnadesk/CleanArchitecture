using Domain.Common;

namespace Domain.Entities
{
    public class Company : BaseAuditableEntity
    {
        public required string Name { get; set; }
        public required Person Statutory { get; set; }
    }
}