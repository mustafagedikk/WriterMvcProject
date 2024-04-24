using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Heading
        public ActionResult Index()
        {
            var Headingvalues = hm.GetList();


            return View(Headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> CategoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categoryvalues = CategoryValues;



            List<SelectListItem> writerlist = (from x in wm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName + " " + x.WriterSurname,
                                                   Value = x.WriterID.ToString()
                                               }
                                             ).ToList();
            ViewBag.writerlist = writerlist;


            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            var headingvalue = hm.GetByID(id);
            List<SelectListItem> Categorylist = (from x in cm.GetList() select new SelectListItem {Value=x.CategoryID.ToString(), Text=x.CategoryName
            }
            ).ToList();

            ViewBag.vlc = Categorylist;
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var value = hm.GetByID(id);
          
            hm.HeadingDelete(value);
            return RedirectToAction("Index");
        }

        public ActionResult PassiveHeading()
        {
            var values = hm.GetListByHeadingStatus();
            return View(values);
        }

    }
}