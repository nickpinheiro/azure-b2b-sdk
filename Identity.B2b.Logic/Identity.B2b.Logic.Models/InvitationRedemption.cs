using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.B2b.Logic.Models
{
        public class InvitationRedemption
        {
            public string odatacontext { get; set; }
            public string id { get; set; }
            public string inviteRedeemUrl { get; set; }
            public string invitedUserDisplayName { get; set; }
            public string invitedUserType { get; set; }
            public string invitedUserEmailAddress { get; set; }
            public bool sendInvitationMessage { get; set; }
            public string inviteRedirectUrl { get; set; }
            public string status { get; set; }
            public Invitedusermessageinfo invitedUserMessageInfo { get; set; }
            public Inviteduser invitedUser { get; set; }
        }

        public class Invitedusermessageinfo
        {
            public object messageLanguage { get; set; }
            public object customizedMessageBody { get; set; }
            public Ccrecipient[] ccRecipients { get; set; }
        }

        public class Ccrecipient
        {
            public Emailaddress emailAddress { get; set; }
        }

        public class Emailaddress
        {
            public object name { get; set; }
            public object address { get; set; }
        }

        public class Inviteduser
        {
            public string id { get; set; }
        }
    }
