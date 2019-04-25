namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Remark Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Remark}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IRemarkRepository" />
    public class RemarkRepository:EfRepository<Remark>,IRemarkRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemarkRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public RemarkRepository(MrsContext dbContext):base(dbContext)
        { }
    }
}
