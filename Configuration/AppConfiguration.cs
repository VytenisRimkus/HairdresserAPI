using HairdresserAPI.DatabaseContext;
using HairdresserAPI.Interfaces;
using HairdresserAPI.Repositories;
using HairdresserAPI.Services;
using Microsoft.EntityFrameworkCore;


namespace HairdresserAPI.Configuration;

public static class AppConfiguration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<AppDbContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 35)))
                .EnableSensitiveDataLogging(true)
                .LogTo(Console.WriteLine, LogLevel.Information));
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserManagementPrivateService, UserManagementPrivateService>();
        services.AddScoped<IUserManagementRepository, UserManagementRepository>();
        services.AddScoped<IUserMappingService, UserMappingService>();

        services.AddScoped<IHairdresserPrivateService, HairdresserPrivateService>();
        services.AddScoped<IHairdresserRepository, HairdresserRepository>();

        services.AddScoped<ITimeSlotPrivateService, TimeSlotPrivateService>();
        services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
    }

    public static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("swagger/");
                    return;
                }

                await next.Invoke();
            });
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
