namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Genre Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Genre}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ICultureObjectRepository" />
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenreRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public GenreRepository(MrsContext dbContext) : base(dbContext)
        { }
    }
}
