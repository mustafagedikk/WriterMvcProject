using BusinessLayer.Concrete;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace WriterMvcProject.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index(int p=1)
        {
            var values = adminManager.GetList().ToPagedList(p,10);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        { // Admin rollerini listeleyen bir IQueryable oluşturduk
            var roles = adminManager.GetList().Select(x => x.AdminRole);
            var UniqueRoles = new HashSet<string>(roles);
            List<SelectListItem> RoleList = UniqueRoles.Select(role => new SelectListItem
            {
                Text = role,
                Value = role // Eğer adminID'yi değil, role'ü kullanmak istiyorsanız burada role'ü belirtmelisiniz
            }).ToList();

            ViewBag.rolelist = RoleList;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var value = adminManager.GetByID(id);
            return View(value);


        }
        [HttpPost]

        public ActionResult EditAdmin(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");

        }
    }
}