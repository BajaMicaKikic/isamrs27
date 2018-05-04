﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents base class of certain users.
    /// </summary>
    public class User:BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Remarks = new List<Remark>();
            PropAds = new List<PropAd>();
        }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        /// 
        [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [Required]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public long AccountId { get; set; }
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public Account Account { get; set; }
        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public ICollection<Remark> Remarks { get; set; }
        /// <summary>
        /// Gets or sets the property ads.
        /// </summary>
        /// <value>
        /// The property ads.
        /// </value>
        public ICollection<PropAd> PropAds { get; set; }
    }
}
