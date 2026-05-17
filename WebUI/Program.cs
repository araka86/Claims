using WebUI.Components;
using Application.Interfaces;
using Infrastructure.Services;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//регистрация DI
builder.Services.AddScoped<ITenantProvider, TenantProvider>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//регистрация сервиса
builder.Services.AddScoped<Application.Services.FakeDataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
