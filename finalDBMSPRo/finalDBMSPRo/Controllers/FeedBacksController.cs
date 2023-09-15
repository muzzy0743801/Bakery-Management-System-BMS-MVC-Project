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
    public class FeedBacksController : Controller
    {
        private DBMS_BMSEntities db = new DBMS_BMSEntities();

        // GET: FeedBacks
        public ActionResult Index()
        {
            var feedBacks = db.FeedBacks.Include(f => f.Customer).Include(f => f.Employee);
            return View(feedBacks.ToList());
        }

        // GET: FeedBacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // GET: FeedBacks/Create
        public ActionResult Create()
        {
            ViewBag.Customer_id = new SelectList(db.Customers, "CustomerId", "FirstName");
            ViewBag.Employee_id = new SelectList(db.Employees, "empId", "FirstName");
            return View();
        }

        // POST: FeedBacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FbId,Descriptions,Fb_Date,Customer_id,Employee_id")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.FeedBacks.Add(feedBack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_id = new SelectList(db.Customers, "CustomerId", "FirstName", feedBack.Customer_id);
            ViewBag.Employee_id = new SelectList(db.Employees, "empId", "FirstName", feedBack.Employee_id);
            return View(feedBack);
        }

        // GET: FeedBacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_id = new SelectList(db.Customers, "CustomerId", "FirstName", feedBack.Customer_id);
            ViewBag.Employee_id = new SelectList(db.Employees, "empId", "FirstName", feedBack.Employee_id);
            return View(feedBack);
        }

        // POST: FeedBacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FbId,Descriptions,Fb_Date,Customer_id,Employee_id")] FeedBack feedBack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedBack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_id = new SelectList(db.Customers, "CustomerId", "FirstName", feedBack.Customer_id);
            ViewBag.Employee_id = new SelectList(db.Employees, "empId", "FirstName", feedBack.Employee_id);
            return View(feedBack);
        }

        // GET: FeedBacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedBack feedBack = db.FeedBacks.Find(id);
            if (feedBack == null)
            {
                return HttpNotFound();
            }
            return View(feedBack);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedBack feedBack = db.FeedBacks.Find(id);
            db.FeedBacks.Remove(feedBack);
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
