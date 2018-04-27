namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Culture Object Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.CultureObject}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.CultureObject}" />
    interface ICultureObjectRepository :IRepository<CultureObject>,IAsyncRepository<CultureObject>
    {
        // Add method signature.
    }
}
