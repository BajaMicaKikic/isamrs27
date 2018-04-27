namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Account Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.Account}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.Account}" />
    interface IAccountRepository :IRepository<Account>,IAsyncRepository<Account>
    {
        // Add method signatures.
    }
}
