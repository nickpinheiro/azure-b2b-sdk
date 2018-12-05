using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Threading.Tasks;

namespace Identity.B2b.Logic.Mail
{
    public class Invitation
    {
        private const string fromAddress = "noreply@modernappz.com";

        public static async Task SendCustomInvitationAsync(Models.Invitation invitation)
        {
            var apiKey = ConfigurationManager.AppSettings["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress(fromAddress, "Woodgrove Track"));
            msg.SetSubject("You are invited to join the Woodgrove Track App");

            msg.AddTo(new EmailAddress(invitation.InvitedUserEmailAddress, invitation.InvitedUserDisplayName));

            msg.HtmlContent = "<p>Hi "+invitation.InvitedUserDisplayName+"!<p>Click the link below to joing the Woodgrove Track App</p><p>"+invitation.InviteUrl+"</p>";

            var response = await client.SendEmailAsync(msg);
        }
    }
}
