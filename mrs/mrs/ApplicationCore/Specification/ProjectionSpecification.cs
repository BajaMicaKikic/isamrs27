namespace mrs.ApplicationCore.Specification
{
    using mrs.ApplicationCore.Entities;

    public class ProjectionSpecification : BaseSpecification<Projection>
    {
        public ProjectionSpecification(long projectionId)
            : base(p => p.Id == projectionId)
        {
            AddInclude(o => o.Screenings);
        }
    }
}