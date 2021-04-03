using MvcGrid.Models;
using MvcGrid.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGrid.Controllers
{
    public class GridController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {

            var model = db.Staffs.ToList();
            return View(model);
        }


        public ActionResult Add()
        {
            List<SelectListItem> countries = (
                from i in db.Countries.ToList()
                select new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();

            ViewBag.Countries = countries;

            return View();
        }
        [HttpPost]
        public ActionResult Add(Staff staff)
        {
            var model = db.Countries.Where(x => x.Id == staff.Country.Id).FirstOrDefault();
            staff.Country = model;
            db.Staffs.Add(staff);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var staff = db.Staffs.Where(x => x.Id == id).FirstOrDefault();

            List<SelectListItem> countries = (
                from i in db.Countries.ToList()
                select new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList();

            ViewBag.Countries = countries;

            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            var model = db.Staffs.Where(x => x.Id == staff.Id).FirstOrDefault();
            model.FirstName = staff.FirstName;
            model.LastName = staff.LastName;
            model.Age = staff.Age;

            var country = db.Countries.Where(x => x.Id == staff.Country.Id).FirstOrDefault();
            model.Country = country;

            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id!=null)
            {
                var staff = db.Staffs.Where(x => x.Id == id).FirstOrDefault();
                if (staff!=null)
                {
                    db.Staffs.Remove(staff);

                    int deger = db.SaveChanges();
                    if (deger>0)
                    {
                        //veri tabanı etkilendi
                    }
                    else
                    {
                        //veri tabanı etkilenmedi
                    }
                }
            }

            return View();
        }
    }
}