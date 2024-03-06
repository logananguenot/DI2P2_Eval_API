using Di2P2Eval.DbContext;
using Di2P2Eval.Repositories;
using Di2P2Eval.Repositories.Contracts;
using Di2P2Eval.Services;
using Di2P2Eval.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
   .ConfigureServices((hostBuilder, services) =>
   {

       services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));

       services.AddScoped<IUserService, UserService>();

       services.AddScoped<IUserRepository, UserRepository>();
   })
    .Build();

host.Run();
