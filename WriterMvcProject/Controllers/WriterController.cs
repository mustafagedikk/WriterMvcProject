using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var Writervalues = wm.GetList();
            return View(Writervalues);
        }
    }
}