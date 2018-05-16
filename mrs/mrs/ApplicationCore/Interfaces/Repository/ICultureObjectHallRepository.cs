﻿namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Culture Object Hall Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.CultureObject}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.CultureObject}" />
    public interface ICultureObjectHallRepository : IRepository<CultureObjectHall>, IAsyncRepository<CultureObjectHall>
    {
        // Add method signatures.
    }
}