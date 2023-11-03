using HairdresserAPI.DatabaseContext;
using HairdresserAPI.UserDomain.UserManagement;
using HairdresserAPI.UserDomain.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace HairdresserAPI.Configuration;

public static class AppConfiguration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserManagementPrivateService, UserManagementPrivateService>();
        services.AddScoped<IUserManagementRepository, UserManagementRepository>();
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<AppDbContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 35)))
                .EnableSensitiveDataLogging(true)
                .LogTo(Console.WriteLine, LogLevel.Information));
    }

    public static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}
