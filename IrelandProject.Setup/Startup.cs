using IrelandTest.Domain.Interfaces.Repositories;
using IrelandTest.Infra.Repositories;
using IrelandTest.Setup.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IrelandTest.Setup
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureApp(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureRepositories(services);

            services.AddMongoDBClientConfiguration(Configuration)
                    .MongoDBContext(Configuration);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //Example:
            //services.AddScoped<IUserService, UserService>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            //Example:
            //services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

    }
}
