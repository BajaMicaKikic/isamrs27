﻿namespace mrs
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using global::Infrastructure.AppIdentity;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.Extensions.DependencyInjection;
    using mrs.ApplicationCore.Interfaces.Repository;
    using mrs.Infrastructure.AppIdentity;
    using mrs.Infrastructure.Data;

    public class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var mrsContext = services.GetRequiredService<MrsContext>();
                    var idnContext = services.GetRequiredService<AppIdentityDbContext>();

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

                    var projectionRepository = services.GetRequiredService<IProjectionRepository>();
                    var genreRepository = services.GetRequiredService<IGenreRepository>();
                    var actorRepository = services.GetRequiredService<IActorRepository>();
                    var cultureObjectRepository = services.GetRequiredService<ICultureObjectRepository>();
                    var hallSegmentRepository = services.GetRequiredService<IHallSegmentRepository>();
                    var cultureObjectHallRepository = services.GetRequiredService<ICultureObjectHallRepository>();
                    var screeningRepository = services.GetRequiredService<IScreeningRepository>();
                    var seatRepository = services.GetRequiredService<ISeatRepository>();
                    var seatReservationRepository = services.GetRequiredService<ISeatReservationRepository>();
                    var accountRepository = services.GetRequiredService<IAccountRepository>();
                    var userRepository = services.GetRequiredService<IUserRepository>();

                    if ((idnContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    {
                        AppIdentityDbContextSeed.SeedAsync(userManager, roleManager).Wait();
                    }
                    if ((mrsContext.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    {
                        MrsContextDbContextSeed.SeedAsync(projectionRepository,
                                                      genreRepository,
                                                      actorRepository,
                                                      cultureObjectRepository,
                                                      hallSegmentRepository,
                                                      cultureObjectHallRepository,
                                                      screeningRepository,
                                                      seatRepository,
                                                      seatReservationRepository, 
                                                      accountRepository,
                                                      userRepository).Wait();
                    }
                    
                }
                catch (Exception ex)
                {
                    // TODO: Logging
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            log.Info("Application - Main is invoked");
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
