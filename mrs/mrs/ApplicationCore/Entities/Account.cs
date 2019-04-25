using System.Collections.Generic;

namespace mrs.ApplicationCore.Entities
{
    /// <summary>
    /// Class that represents account types.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Entities.BaseEntity" />
    public class Account:BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public Account()
        {
        }
        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public string AccountType { get; set; }
        private List<User> _users = new List<User>();
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ICollection<User> Users
        {
            get { return _users; }
            set { _users = (List<User>)value; }
        }
    }
}
