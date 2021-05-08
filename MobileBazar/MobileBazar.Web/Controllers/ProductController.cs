using MobileBazar.Entities;
using MobileBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();

        // GET: Product
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ProductTable(string search)
        {
            var products = this.productsService.GetProducts();

            if (string.IsNullOrEmpty(search) == false)
            {
                products = products.Where(
                    p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return this.PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            this.productsService.SaveProduct(product);

            return this.RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productsService.GetProduct(ID);

            return this.PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            this.productsService.UpdateProduct(product);

            return this.RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            this.productsService.DeleteProduct(ID);

            return this.RedirectToAction("ProductTable");
        }
    }
}