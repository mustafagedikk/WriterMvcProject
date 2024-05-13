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
       
        public ActionResult Inbox(string search)
        {
            string p = (string)Session["WriterMail"];
            if (!string.IsNullOrEmpty(search))
            {
                var values = mm.GetListInboxSearch(p, search);
                return View(values);
            }
            else
            {
                var messagelist = mm.GetListInbox(p);
                return View(messagelist);
            }
            
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            var count = mm.GetByCountSenderMessage(p);
            var recievercount = mm.GetByCountReceiverMessage(p);
            var garbagecount = mm.GetByCountGarbageMessage(p);

           
            int valuetask = mm.GetByCountTaskMessage(p);
          
            ViewBag.sendermailcount = count;
            ViewBag.receivercount = recievercount;
            ViewBag.garbagecount = garbagecount;
            ViewBag.Taskmessage = valuetask;
            return PartialView();

        
        }

        public ActionResult Sendbox(string search)

        {
            string p = (string)Session["WriterMail"];

           
            if (!string.IsNullOrEmpty(search))
            {
                var values = mm.GetListSendboxSearch(p, search);
                return View(values);
            }
            else
            {
                var messagelist = mm.GetListSendBox(p);
                return View(messagelist);
            }

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


                string p = (string)Session["WriterMail"];
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


        public ActionResult GarbageMessage()
        {

            string p = (string)Session["WriterMail"];
            var garbagemessagevalues = mm.GetListGarbage(p);
            return View(garbagemessagevalues);
        }
        public ActionResult DeleteMessage(int id)
        {
            var values = mm.GetByID(id);
            values.Status = false;
            values.TaskStatus = false;
            mm.DeleteMessage(values);

            return RedirectToAction("Inbox");

        }
        public ActionResult TaskMessage()
        {

            string p = (string)Session["WriterMail"];
            var taskvalues = mm.GetListByTask(p);

            return View(taskvalues);
        }

    }
}