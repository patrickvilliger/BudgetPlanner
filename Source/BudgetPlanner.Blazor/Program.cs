using Raven.Client.Documents;
using VilligerElectronics.BudgetPlanner.Core;
using VilligerElectronics.BudgetPlanner.DataStore;
using VilligerElectronics.BudgetPlanner.DataStore.BalancePositions;
using VilligerElectronics.BudgetPlanner.DataStore.BudgetPositions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<DocumentStoreProvider>();
builder.Services.AddSingleton<IDocumentStore>(r => r.GetRequiredService<DocumentStoreProvider>().Create());

builder.Services.AddSingleton<IBalanceRepository, BalanceRepository>();
builder.Services.AddSingleton<IBudgetRepository, BudgetRepository>();

builder.Services.AddSingleton<ForecastService>();

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Services.GetRequiredService<IDocumentStore>();

app.Run();
