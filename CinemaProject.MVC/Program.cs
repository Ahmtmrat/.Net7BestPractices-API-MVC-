using Autofac.Extensions.DependencyInjection;
using Autofac;
using CinemaProject.Web.Modules;
using CinemaProject.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CinemaProject.Service.Mapping;
using FluentValidation.AspNetCore;
using CinemaProject.Service.Validations;
using CinemaProject.Web.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CinemaDtoValidator>());




builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Services.AddScoped(typeof(NotFoundDirectorFilter));
builder.Services.AddScoped(typeof(NotFoundGenreFilter));
builder.Services.AddScoped(typeof(NotFoundYearFilter));
builder.Services.AddScoped(typeof(NotFoundIdFilter<>));



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cinema}/{action=Index}/{id?}");

app.Run();
