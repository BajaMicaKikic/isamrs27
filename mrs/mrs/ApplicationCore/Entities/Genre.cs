using System.Collections.Generic;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents genre.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Entities.BaseEntity" />
    public class Genre : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Genre"/> class.
        /// </summary>
        public Genre()
        {
        }
        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        /// <value>
        /// The name of the genre.
        /// </value>
        public string GenreName { get; set; }
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
