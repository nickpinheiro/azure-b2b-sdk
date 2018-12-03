using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity.B2b.Logic.ApiApp.Models
{
    /// <summary>
    /// Invitation class.
    /// </summary>
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
    }
}