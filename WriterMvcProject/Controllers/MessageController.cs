using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntitiyFramework;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Services.Description;
using EntitiyLayer.Concrete;

namespace WriterMvcProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {

            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult Sendbox(string p)
        {
            

            
            var sendbox = mm.GetListSendBox(p);

            return View(sendbox);
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
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                message.SenderMail = "admin@gmail.com"; ///daha sonra sessiondan alacak 
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

      
    }
}