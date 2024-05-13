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
        public ActionResult Inbox(string search)
        {
            string p = (string)Session["AdminUserName"];
         
            if (!string.IsNullOrEmpty(search))
            {
                var values = mm.GetListInboxSearch(p, search);
                return View(values);
            }
            else
            {
                var allvalues = mm.GetListInbox(p);
                return View(allvalues);
            }
        }

        public ActionResult Sendbox(string search)
        {

            string p = (string)Session["AdminUserName"];
            
            

            if (!string.IsNullOrEmpty(search))
            {
                var values = mm.GetListSendboxSearch(p,search);
                return View(values);
            }
            else
            {
                var values = mm.GetListSendBox(p);
                return View(values);
            }
            
        }  

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message, string submitType)
        {
            ValidationResult result = messagevalidator.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToString());
                message.Status = true;
                message.TaskStatus = false;

                if (submitType == "task")
                {
                    message.TaskStatus = true;
                }
                else if (submitType == "send")
                {
                    message.TaskStatus = false;
                }


                string p = (string)Session["AdminUserName"];
                message.SenderMail = p; 
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
           
            string p = (string)Session["AdminUserName"];
            var count = mm.GetByCountSenderMessage(p);
            ViewBag.sendermailcount = count;
            return View(values);
        }

        public ActionResult GarbageMessage()
        {
            
            string p=(string)Session["AdminUserName"];
            var garbagemessagevalues = mm.GetListGarbage(p);
            return View(garbagemessagevalues);
        }

        public ActionResult TaskMessage()
        {

            string p = (string)Session["AdminUserName"];
            var taskvalues = mm.GetListByTask(p);

            return View(taskvalues);
        }
       
        public ActionResult DeleteMessage(int id)
        {
            var values = mm.GetByID(id);
            values.Status = false;
            values.TaskStatus = false;
            mm.DeleteMessage(values);
            
            return RedirectToAction("Inbox");

        }
      


    }
}