using HairdresserAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

AppConfiguration.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

AppConfiguration.ConfigureApp(app);

app.Run();
