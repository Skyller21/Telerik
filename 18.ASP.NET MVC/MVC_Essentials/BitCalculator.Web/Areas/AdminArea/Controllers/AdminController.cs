using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCalculator.Web.Areas.AdminArea.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminArea/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}