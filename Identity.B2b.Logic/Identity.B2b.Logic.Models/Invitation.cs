using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.B2b.Logic.Models
{
    public class Invitation
    {
        /// <summary>
        /// Gets or sets display name.
        /// </summary>
        public string InvitedUserDisplayName { get; set; }

        /// <summary>
        /// Gets or sets display name.
        /// </summary>
        public string InvitedUserEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Invitation Manager should send the email to InvitedUser.
        /// </summary>
        public bool SendInvitationMessage { get; set; }

        /// <summary>
        /// Gets or sets invitation redirect URL
        /// </summary>
        public string InviteRedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets invitation redirect URL
        /// </summary>
        public string InviteUrl { get; set; }
    }
}
