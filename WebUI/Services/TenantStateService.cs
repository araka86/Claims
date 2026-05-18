using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace WebUI.Services;

public class TenantStateService
{
    private readonly ProtectedLocalStorage _storage;

    public TenantStateService(ProtectedLocalStorage storage)
    {
        _storage = storage;
    }


    //<<<<<<<<<<<<<<<<<<<<<<<<STORAGE
    public async Task SaveTenantAsync(Guid tenantId, string tenantName)
    {
        await _storage.SetAsync("tenant-id", tenantId);

        await _storage.SetAsync("tenant-name", tenantName);
    }

    public async Task<(Guid?, string?)> LoadTenantAsync()
    {
        var tenantId = await _storage.GetAsync<Guid>("tenant-id");

        var tenantName = await _storage.GetAsync<string>("tenant-name");

        return (
            tenantId.Success ? tenantId.Value : null,
            tenantName.Success ? tenantName.Value : null
        );
    }
}