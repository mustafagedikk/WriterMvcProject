using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace WriterMvcProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }

        public ActionResult GettAllContent(string p ,int a=1)
        {

            ///search alanı


            if (!string.IsNullOrEmpty(p))
            {
                var values = cm.GetlistforSearch(p).ToPagedList(a, 5);
                return View(values);
            }
            else
            {
                var allvalues = cm.GetList().ToPagedList(a, 5);
                return View(allvalues);
            }

        }
    }
}