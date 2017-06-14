using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransmitterWEB.Controllers
{
    public class ProfileController : _baseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Profile";

            return View();
        }
    }
}
