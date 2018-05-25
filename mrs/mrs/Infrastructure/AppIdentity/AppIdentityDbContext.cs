namespace Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using mrs;
    using mrs.Infrastructure.AppIdentity;
    using System;

    /// <summary>
    /// DB context for account management data.
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser,AppRole,string,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The connection string
        /// </summary>
        private string connString = "server=localhost;database=idn;uid=root;SslMode=none;";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Gets or sets the application users.
        /// </summary>
        /// <value>
        /// The application users.
        /// </value>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        /// <summary>
        /// Gets or sets the application roles.
        /// </summary>
        /// <value>
        /// The application roles.
        /// </value>
        public DbSet<AppRole> AppRoles { get; set; }
        /// <summary>
        /// Gets or sets the application role claims.
        /// </summary>
        /// <value>
        /// The application role claims.
        /// </value>
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        /// <summary>
        /// Gets or sets the appp user claims.
        /// </summary>
        /// <value>
        /// The appp user claims.
        /// </value>
        public DbSet<AppUserClaim> ApppUserClaims { get; set; }
        /// <summary>
        /// Gets or sets the application user logins.
        /// </summary>
        /// <value>
        /// The application user logins.
        /// </value>
        public DbSet<AppUserLogin> AppUserLogins { get; set; }
        /// <summary>
        /// Gets or sets the application user roles.
        /// </summary>
        /// <value>
        /// The application user roles.
        /// </value>
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        /// <summary>
        /// Gets or sets the application user tokens.
        /// </summary>
        /// <value>
        /// The application user tokens.
        /// </value>
        public DbSet<AppUserToken> AppUserTokens { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseMySQL(connString);
            }
            catch (System.Exception e)
            {
                log.Error($"{e.Message}", e);
            }
        }
        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.ApplicationUser", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd().HasMaxLength(256);

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken().HasMaxLength(256);

                b.Property<string>("Email")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed");

                b.Property<bool>("LockoutEnabled");

                b.Property<DateTimeOffset?>("LockoutEnd");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash").HasMaxLength(256);

                b.Property<string>("PhoneNumber").HasMaxLength(256);

                b.Property<bool>("PhoneNumberConfirmed");

                b.Property<string>("SecurityStamp").HasMaxLength(256);

                b.Property<bool>("TwoFactorEnabled");

                b.Property<string>("UserName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppRole", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd().HasMaxLength(256);

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Name")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppRoleClaim", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("RoleId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserClaim", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserLogin", b =>
            {
                b.Property<string>("LoginProvider").HasMaxLength(256);

                b.Property<string>("ProviderKey").HasMaxLength(256); ;

                b.Property<string>("ProviderDisplayName");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserRole", b =>
            {
                b.Property<string>("UserId").HasMaxLength(256);

                b.Property<string>("RoleId").HasMaxLength(256);

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserToken", b =>
            {
                b.Property<string>("UserId").HasMaxLength(256);

                b.Property<string>("LoginProvider").HasMaxLength(256);

                b.Property<string>("Name").HasMaxLength(256);

                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

              modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppRoleClaim", b =>
              {
                  b.HasOne("mrs.Infrastructure.AppIdentity.AppRole")
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade);
              });

              modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserRole", b =>
              {
                  b.HasOne("mrs.Infrastructure.AppIdentity.AppRole")
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade);

                  b.HasOne("mrs.Infrastructure.AppIdentity.ApplicationUser")
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade);
              });

              modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserLogin", b =>
              {
                  b.HasOne("mrs.Infrastructure.AppIdentity.ApplicationUser")
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade);
              });

              modelBuilder.Entity("mrs.Infrastructure.AppIdentity.AppUserClaim", b =>
              {
                  b.HasOne("mrs.Infrastructure.AppIdentity.ApplicationUser")
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade);
              });
              
            base.OnModelCreating(modelBuilder);
        }
    }
}
