using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FakeDataService
    {
        private readonly ITenantProvider _tenantProvider;

        public FakeDataService(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        private readonly List<ClientRecord> _records =
        [
            new()
        {
            Id = Guid.NewGuid(),
            TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Client A Record 1",
            Status = "Active"
        },

        new()
        {
            Id = Guid.NewGuid(),
            TenantId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Client A Record 2",
            Status = "Pending"
        },

        new()
        {
            Id = Guid.NewGuid(),
            TenantId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Client B Record 1",
            Status = "Completed"
        }
        ];

        public List<ClientRecord> GetData()
        {
            return _records
                .Where(x => x.TenantId == _tenantProvider.TenantId)
                .ToList();
        }
    }


}
