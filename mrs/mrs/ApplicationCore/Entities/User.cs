using System.Collections.Generic;

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
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        public string ConfirmPassword { get; set; }// TODO: Stefan Kikic: Check purpose of this attribute!
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public long AccountId { get; set; }
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public Account Account { get; set; }
        /// <summary>
        /// The remarks
        /// </summary>
        private List<Remark> _remarks = new List<Remark>();
        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public ICollection<Remark> Remarks
        {
            get { return _remarks; }
            set { _remarks = (List<Remark>)value; }
        }
        /// <summary>
        /// The property ads
        /// </summary>
        private List<PropAd> _propAds = new List<PropAd>();
        /// <summary>
        /// Gets or sets the property ads.
        /// </summary>
        /// <value>
        /// The property ads.
        /// </value>
        public ICollection<PropAd> PropAds
        {
            get { return _propAds; }
            set { _propAds = (List<PropAd>)value; }
        }
    }
}
