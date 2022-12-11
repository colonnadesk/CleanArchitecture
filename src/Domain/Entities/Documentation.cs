using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
