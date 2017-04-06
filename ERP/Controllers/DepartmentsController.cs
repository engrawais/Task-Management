using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Models;

namespace ERP.Controllers
{
    public class DepartmentsController : Controller
    {
        private DataCollectionEntities db = new DataCollectionEntities();

        // GET: /Departments/
        public ActionResult Index()
        {
            return View(db.TM_Department.ToList());
        }

        // GET: /Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_Department tm_department = db.TM_Department.Find(id);
            if (tm_department == null)
            {
                return HttpNotFound();
            }
            return View(tm_department);
        }

        // GET: /Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TDepID,DepName")] TM_Department tm_department)
        {
            if (ModelState.IsValid)
            {
                db.TM_Department.Add(tm_department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tm_department);
        }

        // GET: /Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_Department tm_department = db.TM_Department.Find(id);
            if (tm_department == null)
            {
                return HttpNotFound();
            }
            return View(tm_department);
        }

        // POST: /Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TDepID,DepName")] TM_Department tm_department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tm_department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tm_department);
        }

        // GET: /Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_Department tm_department = db.TM_Department.Find(id);
            if (tm_department == null)
            {
                return HttpNotFound();
            }
            return View(tm_department);
        }

        // POST: /Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TM_Department tm_department = db.TM_Department.Find(id);
            db.TM_Department.Remove(tm_department);
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
