namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Actor Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Actor}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IActorRepository" />
    public class ActorRepository:EfRepository<Actor>,IActorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActorRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ActorRepository(MrsContext dbContext) : base(dbContext)
        { }
    }
}
