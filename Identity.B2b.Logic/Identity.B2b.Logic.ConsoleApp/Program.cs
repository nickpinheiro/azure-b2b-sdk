using Identity.B2b.Logic.Mail;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Identity.B2b.Logic.Models;

namespace Identity.B2b.Logic.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Microsoft graph resource.
        /// </summary>
        static readonly string GraphResource = "https://graph.microsoft.com";

        /// <summary>
        /// Microsoft graph invite endpoint.
        /// </summary>
        static readonly string InviteEndPoint = "https://graph.microsoft.com/v1.0/invitations";

        /// <summary>
        ///  Authentication endpoint to get token.
        /// </summary>
        static readonly string EstsLoginEndpoint = "https://login.microsoftonline.com";

        /// <summary>
        /// This is the tenantid of the tenant you want to invite users to.
        /// </summary>
        private static readonly string TenantID = ConfigurationManager.AppSettings["ida:TenantID"];

        /// <summary>
        /// This is the application id of the application that is registered in the above tenant.
        /// The required scopes are available in the below link.
        /// https://developer.microsoft.com/graph/docs/api-reference/v1.0/api/invitation_post
        /// </summary>
        private static readonly string TestAppClientId = ConfigurationManager.AppSettings["ida:TestAppClientId"];

        /// <summary>
        /// Client secret of the application.
        /// </summary>
        private static readonly string TestAppClientSecret = @ConfigurationManager.AppSettings["ida:TestAppClientSecret"];

        /// <summary>
        /// This is the email address of the user you want to invite.
        /// </summary>
        private static readonly string InvitedUserEmailAddress = @ConfigurationManager.AppSettings["InvitedUserEmailAddress"];

        /// <summary>
        /// This is the display name of the user you want to invite.
        /// </summary>
        private static readonly string InvitedUserDisplayName = @ConfigurationManager.AppSettings["InvitedUserDisplayName"];

        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Optional arguments</param>
        static void Main(string[] args)
        {
            Models.Invitation invitation = CreateInvitation();

            Task.Run(async () =>
            {
                // Do any async anything you need here without worry
                await SendInvitationAsync(invitation);

            }).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create the invitation object.
        /// </summary>
        /// <returns>Returns the invitation object.</returns>
        private static Models.Invitation CreateInvitation()
        {
            // Set the invitation object.
            Models.Invitation invitation = new Models.Invitation();
            invitation.InvitedUserDisplayName = InvitedUserDisplayName;
            invitation.InvitedUserEmailAddress = InvitedUserEmailAddress;
            invitation.InviteRedirectUrl = "https://www.microsoft.com";
            invitation.SendInvitationMessage = true;
            return invitation;
        }

        /// <summary>
        /// Send the guest user invite request.
        /// </summary>
        /// <param name="invitation">Invitation object.</param>
        private static async Task SendInvitationAsync(Models.Invitation invitation)
        {
            string accessToken = GetAccessToken();

            HttpClient httpClient = GetHttpClient(accessToken);

            // Make the invite call. 
            HttpContent content = new StringContent(JsonConvert.SerializeObject(invitation));
            content.Headers.Add("ContentType", "application/json");
            var postResponse = httpClient.PostAsync(InviteEndPoint, content).Result;
            string serverResponse = postResponse.Content.ReadAsStringAsync().Result;

            Console.WriteLine(serverResponse);

            // Send custom invitation 
            await Mail.Invitation.SendCustomInvitationAsync(invitation);

            Console.ReadLine();
        }

        /// <summary>
        /// Get the HTTP client.
        /// </summary>
        /// <param name="accessToken">Access token</param>
        /// <returns>Returns the Http Client.</returns>
        private static HttpClient GetHttpClient(string accessToken)
        {
            // setup http client.
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(300);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Add("client-request-id", Guid.NewGuid().ToString());
            Console.WriteLine(
                "CorrelationID for the request: {0}",
                httpClient.DefaultRequestHeaders.GetValues("client-request-id").Single());
            return httpClient;
        }

        /// <summary>
        /// Get the access token for our application to talk to microsoft graph.
        /// </summary>
        /// <returns>Returns the access token for our application to talk to microsoft graph.</returns>
        private static string GetAccessToken()
        {
            string accessToken = null;

            // Get the access token for our application to talk to microsoft graph.
            try
            {
                AuthenticationContext testAuthContext =
                    new AuthenticationContext(string.Format("{0}/{1}", EstsLoginEndpoint, TenantID));
                AuthenticationResult testAuthResult = testAuthContext.AcquireTokenAsync(
                    GraphResource,
                    new ClientCredential(TestAppClientId, TestAppClientSecret)).Result;
                accessToken = testAuthResult.AccessToken;
            }
            catch (AdalException ex)
            {
                Console.WriteLine("An exception was thrown while fetching the token: {0}.", ex);
                throw;
            }

            return accessToken;
        }
    }
}
