using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManager.Client.MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        [HttpGet]
        public ActionResult Forbidden()
        {
            return View("Forbidden");
        }

        [HttpGet]
        public ActionResult InternalServer()
        {
            return View("InternalServer");
        }

        [HttpGet]
        public ActionResult UnAuthorized()
        {
            return View("UnAuthorized");
        }

        [HttpGet]
        public ActionResult BadRequest()
        {
            return View("BadRequest");
        }
    }
}