using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db;
        ProductDAL prddal;

        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
            prddal = new ProductDAL(db);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var model = prddal.GetProducts();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = prddal.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = prddal.AddProduct(product);
                if(result>=1)
                return RedirectToAction(nameof(Index));
                else
                    {
                        ViewBag.ErrorMsg = "Something Went Wrong";
                        return View();
                    }

                }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var prd = prddal.GetProductById(id);
            return View(prd);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = prddal.UpdateProduct(product);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMsg = "Something Went Wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var prd = prddal.GetProductById(id);
            return View(prd);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = prddal.DeleteProduct(id);
                if (result >= 1)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMsg = "Something Went Wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
