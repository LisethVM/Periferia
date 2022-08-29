using Microsoft.EntityFrameworkCore;
using Periferia.DataAccess;
using Periferia.DataAccess.Repository;
using Periferia.ServiceContracts;
using Periferia.Services;

var builder = WebApplication.CreateBuilder(args);


string connection = builder.Configuration["ConnectionStrings:StoreDbContext"];
Console.WriteLine(connection);
builder.Services.AddDbContext<TiendaDbContext>(options =>
{
    options.UseSqlServer(connection);
});
builder.Services.AddScoped<DbContext, TiendaDbContext>();

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddTransient<IClientesService,ClientesService>();
builder.Services.AddTransient<IProductosService, ProductosService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
