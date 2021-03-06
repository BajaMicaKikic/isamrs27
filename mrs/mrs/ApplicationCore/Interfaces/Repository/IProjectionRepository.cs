﻿namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Projection Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.Projection}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.Projection}" />
    public interface IProjectionRepository :IRepository<Projection>,IAsyncRepository<Projection>
    {
        // Add method signatures.
        Task<List<Projection>> GetProjectionByScreeningIdAsync(long id);
        //Task<Projection> GetAllProjection();
    }
}
