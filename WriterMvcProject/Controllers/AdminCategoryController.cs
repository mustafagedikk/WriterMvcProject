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

namespace WriterMvcProject.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles="B,A")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            //********using FluentValidation.Results ile kulllanılacak; 
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
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

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);


        }
        [HttpPost]

        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");

        }

    }
}