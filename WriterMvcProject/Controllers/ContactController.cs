using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var values = contactManager.GetList();
            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var values = contactManager.ContactGetByID(id);
            return View(values);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}