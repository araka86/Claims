using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TenantProvider : ITenantProvider
    {
        public Guid TenantId { get; private set; }

        public string TenantName { get; private set; } = "Not Selected";

        public event Action? OnTenantChanged;

        public void SetTenant(Guid tenantId, string tenantName)
        {
            TenantId = tenantId;

            TenantName = tenantName;

            OnTenantChanged?.Invoke();
        }
    }
}
