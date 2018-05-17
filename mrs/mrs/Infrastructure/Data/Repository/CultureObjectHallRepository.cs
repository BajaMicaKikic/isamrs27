namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using mrs.ApplicationCore.Specification;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Class for CultureObjectHall Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.CultureObjectHall}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ICultureObjectHallRepository" />
    public class CultureObjectHallRepository : EfRepository<CultureObjectHall>, ICultureObjectHallRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectHallRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CultureObjectHallRepository(MrsContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Screening>> GetProjByCulObjIdAsync(long id)
        {
            var culObjHalls = await ListAsync(new CultureObjectHallSpecification(id));
            var screenings = new List<Screening>();
            foreach (var hall in culObjHalls)
            {
                screenings.AddRange(hall.Screenings);
            }
            return screenings;
        }
    }
}

