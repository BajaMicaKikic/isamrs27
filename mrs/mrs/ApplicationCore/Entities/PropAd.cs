using System;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents thematic prop.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Entities.BaseEntity" />
    public class PropAd:BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropAd"/> class.
        /// </summary>
        public PropAd()
        { }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long? UserReservedId { get; set; }
        /// <summary>
        /// Gets or sets the property identifier.
        /// </summary>
        /// <value>
        /// The property identifier.
        /// </value>
        public long ThematicPropId { get; set; }
        /// <summary>
        /// Gets or sets the property price.
        /// </summary>
        /// <value>
        /// The property price.
        /// </value>
        public decimal PropPrice { get; set; }
        /// <summary>
        /// Gets or sets the property description.
        /// </summary>
        /// <value>
        /// The property description.
        /// </value>
        public string PropDescription { get; set; }
        /// <summary>
        /// Gets or sets the end bid date.
        /// </summary>
        /// <value>
        /// The end bid date.
        /// </value>
        public DateTime EndBidDate { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }
        /// <summary>
        /// Gets or sets the thematic property.
        /// </summary>
        /// <value>
        /// The thematic property.
        /// </value>
        public ThematicProp ThematicProp { get; set; }
        /// <summary>
        /// Gets or sets the UserReserved.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User UserReserved { get; set; }
    }
}
