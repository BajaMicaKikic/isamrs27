﻿
using System.Collections.Generic;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents Cinemas/Theaters.
    /// </summary>
    public class CultureObject:BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObject"/> class.
        /// </summary>
        public CultureObject()
        {
            Remarks = new List<Remark>();
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the promo description.
        /// </summary>
        /// <value>
        /// The promo description.
        /// </value>
        public string PromoDescription { get; set; }
        /// <summary>
        /// Gets or sets the object discriminator.
        /// </summary>
        /// <value>
        /// The object discriminator.
        /// </value>
        public Object ObjectDiscriminator { get; set; }
        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public ICollection<Remark> Remarks { get; set; }

    }
    /// <summary>
    /// Enum Theater/Cinema
    /// </summary>
    public enum Object
    {
        Theater = 1,
        Cinema = 2
    }
}