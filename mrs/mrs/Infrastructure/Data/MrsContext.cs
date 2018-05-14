namespace mrs.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using mrs.ApplicationCore.Entities;
    using mrs.Infrastructure.Data.Mapping;
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class MrsContext : DbContext
    {
        /// <summary>
        /// The log.
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The connection string
        /// </summary>
        private string connString = "server=localhost;database=mrs;uid=root;SslMode=none;charset=utf8;";
        /// <summary>
        /// Initializes a new instance of the <see cref="MrsContext"/> class.
        /// </summary>
        public MrsContext() : base() 
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public DbSet<Account> Accounts { get; set; }
        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor.
        /// </value>
        public DbSet<Actor> Actor { get; set; }
        /// <summary>
        /// Gets or sets the culture objects.
        /// </summary>
        /// <value>
        /// The culture objects.
        /// </value>
        public DbSet<User> CultureObjects { get; set; }
        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        /// <value>
        /// The genres.
        /// </value>
        public DbSet<Genre> Genres { get; set; }
        /// <summary>
        /// Gets or sets the projections.
        /// </summary>
        /// <value>
        /// The projections.
        /// </value>
        public DbSet<Projection> Projections { get; set; }
        /// <summary>
        /// Gets or sets the property ads.
        /// </summary>
        /// <value>
        /// The property ads.
        /// </value>
        public DbSet<PropAd> PropAds { get; set; }
        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public DbSet<User> Remarks { get; set; }
        /// <summary>
        /// Gets or sets the thematic props.
        /// </summary>
        /// <value>
        /// The thematic props.
        /// </value>
        public DbSet<ThematicProp> ThematicProps { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }
       
        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
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
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new ActorMap());
            modelBuilder.ApplyConfiguration(new CultureObjectMap());
            modelBuilder.ApplyConfiguration(new GenreMap());
            modelBuilder.ApplyConfiguration(new ProjectionMap());
            modelBuilder.ApplyConfiguration(new PropAdMap());
            modelBuilder.ApplyConfiguration(new RemarkMap());
            modelBuilder.ApplyConfiguration(new ThematicPropMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
