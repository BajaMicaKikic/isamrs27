using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mrs.ApplicationCore.Interfaces;
using mrs.ApplicationCore.Interfaces.Repository;
using mrs.Infrastructure.Data;
using mrs.Infrastructure.Data.Repository;

namespace mrs
{
    public class Startup
    {
        private IServiceCollection _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
            ConfigureTestingServices(services);

            // use real database
            // ConfigureProductionServices(services);

        }

        public void ConfigureTestingServices(IServiceCollection services)
        {
            services.AddDbContext<MrsContext>();
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<MrsContext>();
            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<ICultureObjectRepository, CultureObjectRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IProjectionRepository, ProjectionRepository>();
            services.AddScoped<IPropAdRepository, PropAddRepository>();
            services.AddScoped<IRemarkRepository, RemarkRepository>();
            services.AddScoped<IThematicPropRepository, ThematicPropRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
