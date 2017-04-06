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
    public class DailyTasksController : Controller
    {
        private DataCollectionEntities db = new DataCollectionEntities();

        // GET: /DailyTasks/
        public ActionResult Index()
        {
            return View(db.TM_DailySheet.ToList());
        }

        // GET: /DailyTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_DailySheet tm_dailysheet = db.TM_DailySheet.Find(id);
            if (tm_dailysheet == null)
            {
                return HttpNotFound();
            }
            return View(tm_dailysheet);
        }

        // GET: /DailyTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DailyTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TDID,ProjectID,DepartmentID,TaskName,AssignTime,StartTime,ActualTime,EndTime,Status,Remarks,TaskDescription,Date,Repeat,Proirity,NumOfDays")] TM_DailySheet tm_dailysheet)
        {
            if (ModelState.IsValid)
            {
                db.TM_DailySheet.Add(tm_dailysheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tm_dailysheet);
        }

        // GET: /DailyTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_DailySheet tm_dailysheet = db.TM_DailySheet.Find(id);
            if (tm_dailysheet == null)
            {
                return HttpNotFound();
            }
            return View(tm_dailysheet);
        }

        // POST: /DailyTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TDID,ProjectID,DepartmentID,TaskName,AssignTime,StartTime,ActualTime,EndTime,Status,Remarks,TaskDescription,Date,Repeat,Proirity,NumOfDays")] TM_DailySheet tm_dailysheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tm_dailysheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tm_dailysheet);
        }

        // GET: /DailyTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TM_DailySheet tm_dailysheet = db.TM_DailySheet.Find(id);
            if (tm_dailysheet == null)
            {
                return HttpNotFound();
            }
            return View(tm_dailysheet);
        }

        // POST: /DailyTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TM_DailySheet tm_dailysheet = db.TM_DailySheet.Find(id);
            db.TM_DailySheet.Remove(tm_dailysheet);
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
