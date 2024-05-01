using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Default
        public PartialViewResult Index(int id=0)
        {
            var values = cm.GetListByHeadingID(id);
            
            return PartialView(values);
        }

        public ActionResult Headings()
        {
            var values = hm.GetList();
            return View(values);
        }
    }
}