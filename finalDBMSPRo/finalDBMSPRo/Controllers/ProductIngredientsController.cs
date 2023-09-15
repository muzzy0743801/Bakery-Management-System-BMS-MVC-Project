using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using finalDBMSPRo.Models;

namespace finalDBMSPRo.Controllers
{
    public class ProductIngredientsController : Controller
    {
        private DBMS_BMSEntities db = new DBMS_BMSEntities();

        // GET: ProductIngredients
        public ActionResult Index()
        {
            var productIngredients = db.ProductIngredients.Include(p => p.Product);
            return View(productIngredients.ToList());
        }

        // GET: ProductIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            return View(productIngredient);
        }

        // GET: ProductIngredients/Create
        public ActionResult Create()
        {
            ViewBag.Product_id = new SelectList(db.Products, "ProId", "Pro_Name");
            return View();
        }

        // POST: ProductIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Proc_Ing_id,Proc_Ing_Name,Product_id")] ProductIngredient productIngredient)
        {
            if (ModelState.IsValid)
            {
                db.ProductIngredients.Add(productIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_id = new SelectList(db.Products, "ProId", "Pro_Name", productIngredient.Product_id);
            return View(productIngredient);
        }

        // GET: ProductIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_id = new SelectList(db.Products, "ProId", "Pro_Name", productIngredient.Product_id);
            return View(productIngredient);
        }

        // POST: ProductIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Proc_Ing_id,Proc_Ing_Name,Product_id")] ProductIngredient productIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_id = new SelectList(db.Products, "ProId", "Pro_Name", productIngredient.Product_id);
            return View(productIngredient);
        }

        // GET: ProductIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            if (productIngredient == null)
            {
                return HttpNotFound();
            }
            return View(productIngredient);
        }

        // POST: ProductIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductIngredient productIngredient = db.ProductIngredients.Find(id);
            db.ProductIngredients.Remove(productIngredient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
