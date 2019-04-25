namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for ThematicProp Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.ThematicProp}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IThematicPropRepository" />
    public class ThematicPropRepository:EfRepository<ThematicProp>,IThematicPropRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThematicPropRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ThematicPropRepository(MrsContext dbContext) : base(dbContext)
        { }
    }
}
