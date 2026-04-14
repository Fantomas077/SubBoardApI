using MudBlazor.Services;
using SubBoard.Blazor.Components;
using SubBoard.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("SubBoardApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7111/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
// Inject HttpClient directly
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("SubBoardApi"));

// Register CategoryService
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<SubscriptionService>();
builder.Services.AddScoped<DashboardService>();

builder.Services.AddMudServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
