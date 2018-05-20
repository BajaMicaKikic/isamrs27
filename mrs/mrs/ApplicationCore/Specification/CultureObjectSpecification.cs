namespace mrs.ApplicationCore.Specification
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Class that provides specifications for Culture Object entity.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Specification.BaseSpecification{mrs.ApplicationCore.Entities.CultureObject}" />
    public class CultureObjectSpecification : BaseSpecification<CultureObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectSpecification"/> class.
        /// </summary>
        /// <param name="cultureObjectId">The culture object identifier.</param>
        public CultureObjectSpecification(long cultureObjectId)
            : base(co => co.Id == cultureObjectId)
        {
            AddInclude(o => o.CultureObjectHalls);
            AddInclude(o => o.Remarks);
        }
    }
}