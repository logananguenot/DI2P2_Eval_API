using Di2P2Eval.Repositories.Contracts;
using Di2P2Eval.Repositories;
using Di2P2Eval.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Di2P2Eval.Services.Contracts;
using Di2P2Eval.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((hostBuilder, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IEventRepository, EventRepository>();
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();