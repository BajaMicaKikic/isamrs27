namespace mrs.ApplicationCore.Specification
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Class that 
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Specification.BaseSpecification{mrs.ApplicationCore.Entities.CultureObjectHall}" />
    public class CultureObjectHallSpecification : BaseSpecification<CultureObjectHall>
    {
        public CultureObjectHallSpecification(long cultureObjectId)
            : base(co => co.CultureObjectId == cultureObjectId)
        {
            AddInclude(o => o.Screenings);   
        }
    }
}
