using MvcGrid.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var model = db.Staffs.ToList();
            return View();
        }

        public ActionResult List()
        {

            var model = db.Staffs.ToList();
            return View(model);
        }


    }
}