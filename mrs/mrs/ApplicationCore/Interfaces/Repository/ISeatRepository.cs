namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Seat Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.Seat}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.Seat}" />
    public interface ISeatRepository : IRepository<Seat>, IAsyncRepository<Seat>
    {
        Task<List<Seat>> GetSeatByHallSegmentIdAsync(long HallSegmentId);
    }
}
