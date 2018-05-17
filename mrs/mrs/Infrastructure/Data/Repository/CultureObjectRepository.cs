namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using mrs.ApplicationCore.Specification;

    /// <summary>
    /// Class for CultureObject Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.CultureObject}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ICultureObjectRepository" />
    public class CultureObjectRepository : EfRepository<CultureObject>,ICultureObjectRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CultureObjectRepository(MrsContext dbContext):base(dbContext)
        {

        }

        //public async Task<List<Projection>> GetProjByCulObjIdAsync(long id)
        //{
        //    var culObj = await ListAsync(new CultureObjectHallSpecification(id));
        //    var culObjHalls = culObj.CultureObjectHalls;
        //    var screenings = new List<Screening>();
        //    foreach (var hall in culObjHalls)
        //    {
        //        screenings.AddRange(hall.Screenings);
        //    }
        //    var projections = new List<Projection>();
        //    foreach (var screening in screenings)
        //    {
        //        projections.Add(screening.Projection);
        //    }
        //    projections = projections.Distinct().ToList();
        //    return projections;
        //}
    }
}
