using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.B2b.Presentation.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Invitation()
        {
            ViewBag.Message = "Your invitation page.";

            return View();
        }

        [HttpPost]
        public ActionResult Invitation(Models.Invitation invitation)
        {
            WoodgroveTrackApi client = new WoodgroveTrackApi(new Uri("https://woodgrove-track-api.azurewebsites.net"), new AnonymousCredential());
            client.Create(invitation);

            return View("Confirmation");
        }

        public ActionResult Confirmation()
        {
            ViewBag.Message = "Your confirmation page.";

            return View();
        }

        private class AnonymousCredential : ServiceClientCredentials
        {

        }
    }
}