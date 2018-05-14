namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Genre Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.Genre}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.Genre}" />
    public interface IGenreRepository :IRepository<Genre>,IAsyncRepository<Genre>
    {
        // Add method signature
    }
}
