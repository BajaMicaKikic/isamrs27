namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents Grade of Culture Objects.
    /// </summary>
    public class Remark : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Remark"/> class.
        /// </summary>
        public Remark()
        { }
        /// <summary>
        /// Gets or sets the culture object identifier.
        /// </summary>
        /// <value>
        /// The culture object identifier.
        /// </value>
        public long CultureObjectId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }
        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public Grade Grade { get; set; }
        /// <summary>
        /// Gets or sets the culture object.
        /// </summary>
        /// <value>
        /// The culture object.
        /// </value>
        public CultureObject CultureObject { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }
    }
    /// <summary>
    /// Enum of Grades.
    /// </summary>
    public enum Grade
    {
        VeryBad = 1,
        Bad = 2,
        Satisfying = 3,
        Good = 4,
        VeryGood = 5,
        Excellent = 6
    }
}
