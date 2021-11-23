using BudgetPlanner.Blazor.Data;
using Raven.Client.Documents;
using VilligerElectronics.BudgetPlanner.DataStore;
using VilligerElectronics.BudgetPlanner.DataStore.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<BudgetService>();
builder.Services.AddSingleton<IDataAccess, DataAccess>();

builder.Services.AddSingleton<DocumentStoreProvider>();
builder.Services.AddSingleton<IDocumentStore>(r => r.GetRequiredService<DocumentStoreProvider>().Create());

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

app.Run();
