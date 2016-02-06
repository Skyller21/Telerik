using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCalculator.Web.Areas.AdminArea.Controllers
{
    public class NotAdminController : Controller
    {
        // GET: AdminArea/NotAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}