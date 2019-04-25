namespace mrs.ApplicationCore.Specification
{
    using mrs.ApplicationCore.Entities;

    public class ScreeningSpecification : BaseSpecification<Screening>
    {
        public ScreeningSpecification(long screeningId)
            : base(p => p.Id == screeningId)
        {
            AddInclude(s => s.Projection);
            AddInclude(s => s.SeatReservations);
        }
    }
}
