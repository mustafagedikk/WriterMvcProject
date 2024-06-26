﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace WriterMvcProject.Controllers
{
    public class WriterController : Controller
    {
        WriterValidator writervalidator = new WriterValidator();
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult Index(int p=1)
        {
            var Writervalues = wm.GetList().ToPagedList(p,7);
            return View(Writervalues);
        }

        [HttpGet]

        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddWriter (Writer p)
        {
          
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }

            }
                    
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var Writervalue = wm.GetByID(id);
            return View(Writervalue);
        }

        [HttpPost]

        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
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