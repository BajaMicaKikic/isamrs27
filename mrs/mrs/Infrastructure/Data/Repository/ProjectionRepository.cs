namespace mrs.Infrastructure.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using mrs.ApplicationCore.Specification;

    /// <summary>
    /// Class for Projection Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Projection}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IProjectionRepository" />
    public class ProjectionRepository : EfRepository<Projection>, IProjectionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProjectionRepository(MrsContext dbContext) : base(dbContext)
        {
            
        }

        

        public Task<Projection> GetProjectionByScreeningIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        Task<List<Projection>> IProjectionRepository.GetProjectionByScreeningIdAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        //public async Task<List<Projection>> GetProjectionByScreeningIdAsync(long id)
        //{
        //    //var projections = await ListAsync(new ProjectionSpecification(id));
        //    //return projections;
        //}
    }
}
