namespace mrs.ApplicationCore.Entities
{
    using System.Collections.Generic;
    /// <summary>
    /// Class that represents cinema projections and theater plays. 
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Entities.BaseEntity" />
    public class Projection:BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Projection"/> class.
        /// </summary>
        public Projection()
        {
        }
        /// <summary>
        /// Gets or sets the name of the projection.
        /// </summary>
        /// <value>
        /// The name of the projection.
        /// </value>
        public string ProjectionName { get; set; }
        /// <summary>
        /// Gets or sets the actor identifier.
        /// </summary>
        /// <value>
        /// The actor identifier.
        /// </value>
        public long ActorId { get; set; }
        /// <summary>
        /// Gets or sets the genre identifier.
        /// </summary>
        /// <value>
        /// The genre identifier.
        /// </value>
        public long GenreId { get; set; } 
        /// <summary>
        /// Gets or sets the name of the producer.
        /// </summary>
        /// <value>
        /// The name of the producer.
        /// </value>
        public string ProducerName { get; set; }
        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public decimal Duration { get; set; }
        /// <summary>
        /// Gets or sets the poster.
        /// </summary>
        /// <value>
        /// The poster.
        /// </value>
        //public byte[] Poster { get; set; }
        /// <summary>
        /// Gets or sets the short descirption.
        /// </summary>
        /// <value>
        /// The short descirption.
        /// </value>
        public string ShortDescirption { get; set; }
        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>
        /// The genre.
        /// </value>
        public Genre Genre { get; set; }
        /// <summary>
        /// Gets or sets the actor.
        /// </summary>
        /// <value>
        /// The actor.
        /// </value>
        public Actor Actor { get; set; }
        /// <summary>
        /// Gets or sets the type of the projection.
        /// </summary>
        /// <value>
        /// The type of the projection.
        /// </value>
        public ProjectionType ProjectionType { get; set; }
        /// <summary>
        /// The screenings
        /// </summary>
        private List<Screening> _screenings = new List<Screening>();
        /// <summary>
        /// Gets or sets the screenings.
        /// </summary>
        /// <value>
        /// The screenings.
        /// </value>
        public ICollection<Screening> Screenings
        {
            get { return _screenings; }
            set { _screenings = (List<Screening>)value; }
        }
        /// <summary>
        /// The culture objects
        /// </summary>
        //private List<CultureObject> _cultureObjects = new List<CultureObject>();
        ///// <summary>
        ///// Gets or sets the culture objects.
        ///// </summary>
        ///// <value>
        ///// The culture objects.
        ///// </value>
        //public ICollection<CultureObject> CultureObjects
        //{
        //    get { return _cultureObjects; }
        //    set { _cultureObjects = (List<CultureObject>)value; }
        //}
    }

    public enum ProjectionType
    {
        Play = 1,
        Movie = 2
    }
}

