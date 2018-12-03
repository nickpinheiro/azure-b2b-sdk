using Identity.B2b.Logic.ApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Identity.B2b.Logic.ApiApp.Controllers
{
    public class InvitationController : ApiController
    {
        // GET: api/Invitation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Invitation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Invitation
        public void Post([FromBody] Invitation invitation)
        {
            Classes.B2bInvitation.ProcessInvitation(invitation);
        }

        // PUT: api/Invitation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Invitation/5
        public void Delete(int id)
        {
        }
    }
}
