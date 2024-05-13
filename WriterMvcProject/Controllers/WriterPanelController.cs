using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace WriterMvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string writermail = (string)Session["WriterMail"];
            int p = context.Writers.Where(x => x.WriterMail == writermail).Select(x => x.WriterID).FirstOrDefault();
            var writervalue = wm.GetByID(p);
            ViewBag.d = p;

            return View(writervalue);
        }


        [HttpPost]

        public ActionResult WriterProfile(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return View();
        }




        public ActionResult MyHeading(string p)
        {
            Context context = new Context();
            p = (string)Session["WriterMail"];
           var  Writerinfo= context.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var values = hm.GetListByWriter(Writerinfo);
            return View(values);
        }


        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categorylist = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryID.ToString()
                                                 }).ToList();
            ViewBag.categorylist = categorylist;
            return View();
        }
        [HttpPost]

        public ActionResult NewHeading(Heading heading)
        {
           string writermailinfo = (string)Session["WriterMail"];
            var Writerinfo = context.Writers.Where(x => x.WriterMail == writermailinfo).Select(x => x.WriterID).FirstOrDefault();
            ViewBag.d = Writerinfo; 
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            heading.WriterID = Writerinfo;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            var headingvalue = hm.GetByID(id);
            List<SelectListItem> Categorylist = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Value = x.CategoryID.ToString(),
                                                     Text = x.CategoryName
                                                 }
            ).ToList();

            ViewBag.vlc = Categorylist;
            return View(headingvalue);
        }


        [HttpPost]
        public ActionResult EditHeading(Heading heading)


        {
            //heading.HeadingStatus = true;
            hm.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var value = hm.GetByID(id);
            value.HeadingStatus = false;
            hm.HeadingDelete(value);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p=1)
        {
            var getallheadings = hm.GetList().ToPagedList(p, 7);

            return View(getallheadings);
        }

    }
}