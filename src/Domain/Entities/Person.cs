using Domain.Common;

namespace Domain.Entities
{
    public class Person : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
