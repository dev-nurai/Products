using AmazonProducts.Models;
using AmazonProducts.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmazonProducts.Controllers
{
    public class BrandProductsController : Controller
    {
        private readonly IProducts _product;

        public BrandProductsController(IProducts product)
        {
            _product = product;
        }
        // GET: BrandProductsController
        public ActionResult Index()
        {
            var products = _product.GetProducts();
            return View(products);
        }

        // GET: BrandProductsController/Details/5
        public ActionResult Details(int id)
        {
            var products = _product.GetProduct(id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // GET: BrandProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _product.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);

        }

        // GET: BrandProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _product.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: BrandProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _product.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: BrandProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _product.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        // POST: BrandProductsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _product.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
