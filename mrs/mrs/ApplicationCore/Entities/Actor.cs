using System.Collections.Generic;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents Actor.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Entities.BaseEntity" />
    public class Actor:BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Actor"/> class.
        /// </summary>
        public Actor()
        {
        }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// The projections
        /// </summary>
        private List<Projection> _projections = new List<Projection>();
        /// <summary>
        /// Gets or sets the projections.
        /// </summary>
        /// <value>
        /// The projections.
        /// </value>
        public ICollection<Projection> Projections
        {
            get { return _projections; }
            set { _projections = (List<Projection>)value; }
        }
    }
}
