using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}