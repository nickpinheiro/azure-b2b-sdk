using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BD.HSV.Presentation.Web.Controllers
{
    [Authorize]
    public class SharedController : Controller
    {
        public PartialViewResult Menu()
        {
            var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;

            //You get the user’s first and last name below:
            ViewBag.Name = userClaims?.FindFirst("name")?.Value;

            return PartialView();
        }
    }
}