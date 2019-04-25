namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Thematic Prop Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.ThematicProp}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.ThematicProp}" />
    interface IThematicPropRepository :IRepository<ThematicProp>,IAsyncRepository<ThematicProp>
    {
        // Add method signature.
    }
}
