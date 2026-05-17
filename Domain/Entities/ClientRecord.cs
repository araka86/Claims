using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClientRecord
    {
        public Guid Id { get; set; }

        public Guid TenantId { get; set; } //ключ всей multi-tenant архитектуры

        public string Name { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
