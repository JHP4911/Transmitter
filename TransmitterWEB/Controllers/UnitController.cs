using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransmitterWEB.Controllers
{
    public class UnitController : _baseController
    {
        // GET: Wizard
        public ActionResult Index(string id,string name)
        {
            ViewBag.Title = name;
            ViewBag.Id = id;
            return View();
        }
    }
}