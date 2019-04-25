namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for User Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.User}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IUserRepository" />
    public class UserRepository : EfRepository<User>,IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(MrsContext dbContext) : base(dbContext)
        {
        }
    }
}
