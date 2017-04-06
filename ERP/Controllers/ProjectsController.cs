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
    public class ProjectsController : Controller
    {
        private DataCollectionEntities db = new DataCollectionEntities();

        // GET: /Projects/
        public ActionResult Index()
        {
            return View(db.TM_Projects.ToList());
        }

        // GET: /Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_Projects tm_projects = db.TM_Projects.Find(id);
            if (tm_projects == null)
            {
                return HttpNotFound();
            }
            return View(tm_projects);
        }

        // GET: /Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TProID,ProName")] TM_Projects tm_projects)
        {
            if (ModelState.IsValid)
            {
                db.TM_Projects.Add(tm_projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tm_projects);
        }

        // GET: /Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_Projects tm_projects = db.TM_Projects.Find(id);
            if (tm_projects == null)
            {
                return HttpNotFound();
            }
            return View(tm_projects);
        }

        // POST: /Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TProID,ProName")] TM_Projects tm_projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tm_projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tm_projects);
        }

        // GET: /Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_Projects tm_projects = db.TM_Projects.Find(id);
            if (tm_projects == null)
            {
                return HttpNotFound();
            }
            return View(tm_projects);
        }

        // POST: /Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TM_Projects tm_projects = db.TM_Projects.Find(id);
            db.TM_Projects.Remove(tm_projects);
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
