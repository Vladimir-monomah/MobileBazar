using MobileBazar.Entities;
using MobileBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();

        [HttpGet]
        public ActionResult Index()
        {
            var categories = this.categoryService.GetCategories();

            return this.View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            this.categoryService.SaveCategory(category);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = this.categoryService.GetCategory(ID);

            return this.View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            this.categoryService.UpdateCategory(category);
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = this.categoryService.GetCategory(ID);

            return this.View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            this.categoryService.DeleteCategory(category.ID);
            return this.RedirectToAction("Index");
        }
    }
}