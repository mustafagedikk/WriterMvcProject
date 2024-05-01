using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WriterMvcProject.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
       
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
          

            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult Sendbox()

        {
            string p = (string)Session["WriterMail"];
           
            var sendbox = mm.GetListSendBox(p);

            return View(sendbox);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = messagevalidator.Validate(message);
            string p = (string)Session["WriterMail"];
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToString());
               
                message.SenderMail = p;//daha sonra sessiondan alacak 
                mm.AddMessage(message);
                return RedirectToAction("SendBox");
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


    }
}