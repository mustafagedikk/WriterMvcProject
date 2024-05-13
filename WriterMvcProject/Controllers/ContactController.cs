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
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Contact
        public ActionResult Index(string search)
        {
           
           

            if (!string.IsNullOrEmpty(search))
            {
                var values = contactManager.GetListContactSearch(search);

                return View(values);
                   

            }
            else
            {
                var value = contactManager.GetList();
                return View(value);
            }
           
        }

        public ActionResult GetContactDetails(int id)
        {
            var values = contactManager.ContactGetByID(id);
            return View(values);
        }

        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["AdminUserName"];
            var count = mm.GetByCountSenderMessage(p);
            var recievercount = mm.GetByCountReceiverMessage(p);
            var garbagecount = mm.GetByCountGarbageMessage(p);

            int value = contactManager.GetContactCount();
            int valuetask = mm.GetByCountTaskMessage(p);
            ViewBag.contactcount = value;
            ViewBag.sendermailcount = count;
            ViewBag.receivercount = recievercount;
            ViewBag.garbagecount = garbagecount;
            ViewBag.Taskmessage = valuetask;
            return PartialView();
        }
    }
}