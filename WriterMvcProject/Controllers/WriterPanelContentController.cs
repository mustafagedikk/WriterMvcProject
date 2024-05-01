using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            Context c = new Context();

            
             p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
           
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]

        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
           string values = (string)Session["WriterMail"];
            var writerinfo = c.Writers.Where(x => x.WriterMail == values).Select(x => x.WriterID).FirstOrDefault();
            content.WriterID = writerinfo;
            content.ContentStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult TodoList()
        {
            return View();
        }

    }
}