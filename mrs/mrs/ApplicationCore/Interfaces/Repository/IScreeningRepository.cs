﻿namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Screening Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.Screening}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.Screening}" />
    public interface IScreeningRepository : IRepository<Screening>, IAsyncRepository<Screening>
    {
        // Add method signatures.

    }
}