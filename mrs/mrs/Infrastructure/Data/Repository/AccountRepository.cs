namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Account Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Account}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IAccountRepository" />
    public class AccountRepository:EfRepository<Account>,IAccountRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public AccountRepository(MrsContext dbContext) : base(dbContext)
        {

        }
    }
}
