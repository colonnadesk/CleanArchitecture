using Domain.Common;

namespace Domain.Entities
{
    public class Documentation : BaseAuditableEntity
    {
        public DocumentationType Type { get; set; }
        public DateTime GeneratedDateTime { get; set; }
        public string GeneratedAt { get; set; } = string.Empty;
        public required Person GeneratedBy { get; set; }
    }
}
