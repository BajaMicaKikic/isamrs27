namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using mrs.ApplicationCore.Specification;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// Class for Screening Repository pattern. 
    public class ScreeningRepository : EfRepository<Screening>, IScreeningRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreeningRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ScreeningRepository(MrsContext dbContext) : base(dbContext)
        {
        }
        public Projection GetAllProjsByScreenId(long screeningId)
        {
            var screening = GetSingleBySpec(new ScreeningSpecification(screeningId));
            return screening.Projection;
        }

       public async Task<List<Screening>> GetSDTByCOHIdAndProjectionIdAsync(long CultureObjectHallId, long ProjectionId)
        {
            List<Screening> ttt = await ListAllAsync();
            var listScreening = ttt.FindAll(c => c.CultureObjectHallId == CultureObjectHallId && c.ProjectionId == ProjectionId);

            return listScreening;
        }

        public async Task<List<Screening>> GetScreeningByCulObjHallIdAsync(long id)
        {
            var screenings = await ListAsync(new ScreeningSpecification(id));
            return screenings;
        }


    }
}

