using Infrastructure.AppIdentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mrs.ApplicationCore.Interfaces;
using mrs.ApplicationCore.Interfaces.Repository;
using mrs.Infrastructure.AppIdentity;
using mrs.Infrastructure.Data;
using mrs.Infrastructure.Data.Repository;
using mrs.Infrastructure.Services;
using mrs.Interfaces;
using mrs.Services;
using System;

namespace mrs
{
    public class Startup
    {
        /// <summary>
        /// The services
        /// </summary>
        private IServiceCollection _services;
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Configures the development services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
            //ConfigureTestingServices(services);
            // use real database
             ConfigureProductionServices(services);
        }
        /// <summary>
        /// Configures the testing services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureTestingServices(IServiceCollection services)
        {
            services.AddDbContext<MrsContext>();
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("IdentityConnection")));
            ConfigureServices(services);
        }
        /// <summary>
        /// Configures the production services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<MrsContext>();
            services.AddDbContext<AppIdentityDbContext>();

            ConfigureServices(services);
        }
        // This method gets called by the runtime. Use this method to add services to the container.        
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, AppRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.LoginPath = "/Account/Signin";
                options.LogoutPath = "/Account/Signout";
            });

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

            services.AddScoped<IProjectionViewModelService, ProjectionViewModelService>();

            services.AddScoped<ICultureObjectViewModelService, CultureObjectViewModelService>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            services.AddMemoryCache();

            services.AddSession();
            services.AddMvc()
                .AddSessionStateTempDataProvider();

            _services = services;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.        
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env )
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
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
