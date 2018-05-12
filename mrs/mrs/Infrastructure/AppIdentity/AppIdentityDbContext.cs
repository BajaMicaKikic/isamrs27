namespace Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using mrs;
    using mrs.Infrastructure.AppIdentity;
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The connection string
        /// </summary>
        private string connString = "server=localhost;database=idn;uid=root;password=1234;SslMode=none;charset=utf8;";
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
                    .ValueGeneratedOnAdd();

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Email")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed");

                b.Property<bool>("LockoutEnabled");

                b.Property<DateTimeOffset?>("LockoutEnd");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash");

                b.Property<string>("PhoneNumber");

                b.Property<bool>("PhoneNumberConfirmed");

                b.Property<string>("SecurityStamp");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider");

                b.Property<string>("ProviderKey");

                b.Property<string>("ProviderDisplayName");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("RoleId");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("LoginProvider");

                b.Property<string>("Name");

                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                    .WithMany("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
            //{
            //    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
            //        .WithMany("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>")
            //        .HasForeignKey("RoleId")
            //        .OnDelete(DeleteBehavior.Cascade);

            //    b.HasOne("mrs.Infrastructure.AppIdentity.ApplicationUser")
            //        .WithMany("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>")
            //        .HasForeignKey("UserId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
            //{
            //    b.HasOne("mrs.Infrastructure.AppIdentity.ApplicationUser")
            //        .WithMany("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>")
            //        .HasForeignKey("UserId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
            //{
            //    b.HasOne("mrs.Infrastructure.AppIdentity.ApplicationUser")
            //        .WithMany("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>")
            //        .HasForeignKey("UserId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
