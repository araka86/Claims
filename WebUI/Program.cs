using WebUI.Components;

using Application.Interfaces;

using Infrastructure.Services;

using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// ======================
// SERVICES
// ======================

// Tenant Provider
builder.Services.AddScoped<ITenantProvider, TenantProvider>();

// Fake data service
builder.Services.AddScoped<FakeDataService>();

// Browser storage
builder.Services.AddScoped<ProtectedLocalStorage>();

// Tenant state service
builder.Services.AddScoped<TenantStateService>();

// Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// ======================
// PIPELINE
// ======================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();