using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GACBackend.Models;

namespace GACBackend.Controllers
{
    public class TimeDetailsController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: TimeDetails
        public ActionResult Index()
        {
            
            return View(db.Employees.ToList());
        }

        // GET: TimeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeDetails timeDetails = db.TimeDetails.Find(id);
            if (timeDetails == null)
            {
                return HttpNotFound();
            }
            return View(timeDetails);
        }
        public ActionResult TimeSheet(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            
            var td = db.TimeDetails.Include(p => p.Employee).Include(p => p.Task).Where(p => p.Code==id).ToList();
            if (td == null)
            {
                return HttpNotFound();
            }
            return View(td);
        }
        // GET: TimeDetails/Create
        public ActionResult Create()
        {
            ViewBag.Code = new SelectList(db.Employees, "Id", "Code");
            ViewBag.Name = new SelectList(db.Tasks, "Id", "Name");
            return View();
        }

        // POST: TimeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday")] TimeDetails timeDetails)
        {
            if (ModelState.IsValid)
            {
                db.TimeDetails.Add(timeDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Code = new SelectList(db.Employees, "Id", "Code", timeDetails.Code);
            ViewBag.Name = new SelectList(db.Tasks, "Id", "Name", timeDetails.Name);
            return View(timeDetails);
        }

        // GET: TimeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeDetails timeDetails = db.TimeDetails.Find(id);
            if (timeDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.Code = new SelectList(db.Employees, "Id", "Code", timeDetails.Code);
            ViewBag.Name = new SelectList(db.Tasks, "Id", "Name", timeDetails.Name);
            return View(timeDetails);
        }

        // POST: TimeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday")] TimeDetails timeDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Code = new SelectList(db.Employees, "Id", "Code", timeDetails.Code);
            ViewBag.Name = new SelectList(db.Tasks, "Id", "Name", timeDetails.Name);
            return View(timeDetails);
        }

        // GET: TimeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeDetails timeDetails = db.TimeDetails.Find(id);
            if (timeDetails == null)
            {
                return HttpNotFound();
            }
            return View(timeDetails);
        }

        // POST: TimeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeDetails timeDetails = db.TimeDetails.Find(id);
            db.TimeDetails.Remove(timeDetails);
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
