using System.Collections.Generic;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents prop.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Entities.BaseEntity" />
    public class ThematicProp : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThematicProp"/> class.
        /// </summary>
        public ThematicProp()
        {
            PropAds = new List<PropAd>();
        }
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropName { get; set; }
        /// <summary>
        /// Gets or sets the property ads.
        /// </summary>
        /// <value>
        /// The property ads.
        /// </value>
        public ICollection<PropAd> PropAds { get; set; }
    }
}
