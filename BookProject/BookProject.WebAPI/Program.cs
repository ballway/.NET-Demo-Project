using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookProject.WebAPI.AutofacModules;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
string databaseType = builder.Configuration.GetSection("DatabaseType").Value;
string connectionString = builder.Configuration.GetSection("ConnectionString").Value;
string persistenceType = builder.Configuration.GetSection("PersistenceType").Value;

// Early init of NLog to allow startup and exception logging, before host is built
NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(@"Configuration\nlog.config");
var logger = NLog.LogManager.Setup().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Integrate with Autofac
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Add your Autofac DI registrations here
        builder.RegisterModule(new BookProjectModule(databaseType, connectionString, persistenceType));
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Exception Handler
    app.UseExceptionHandler("/error");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
