using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITenantProvider
    {
        Guid TenantId { get; }

        string TenantName { get; }

        event Action? OnTenantChanged;

        void SetTenant(Guid tenantId, string tenantName);
    }
}
