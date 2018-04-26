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
            Projections = new List<Projection>();
        }
        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        /// <value>
        /// The name of the genre.
        /// </value>
        public string GenreName { get; set; }
        public ICollection<Projection> Projections { get; set; }
    }
}
