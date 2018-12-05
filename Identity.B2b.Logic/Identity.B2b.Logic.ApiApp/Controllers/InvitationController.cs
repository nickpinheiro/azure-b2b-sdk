using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Identity.B2b.Logic.Models;
using Swashbuckle.Swagger.Annotations;

namespace Identity.B2b.Logic.ApiApp.Controllers
{
    public class InvitationController : ApiController
    {
        // GET api/invitation
        [SwaggerOperation("GetAll")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/invitation/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/invitation
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task PostAsync([FromBody] Invitation invitation)
        {
            await Classes.B2bInvitation.ProcessInvitationAsync(invitation);
        }

        // PUT api/invitation/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/invitation/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
        }
    }
}
