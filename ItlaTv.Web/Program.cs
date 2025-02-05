using ItlaTv.Application.Interfaces;
using ItlaTv.Application.Services;
using ItlaTv.Persistence.Interfaces;
using ItlaTv.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

//dependencies

builder.Services.AddLogging();
builder.Services.AddScoped<ISerieRepository, SerieRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IStudioRepository, StudioRepository>();

builder.Services.AddTransient<ISerieService, SerieService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IStudioService, StudioService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
