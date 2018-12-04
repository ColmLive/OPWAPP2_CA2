﻿using OPWAPP2.DAL;
using OPWAPP2.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OPWAPP2.Controllers
{
    public class WorkController : Controller
    {
        private OPWContext2 db = new OPWContext2();
        public ActionResult Home()
        {

            return RedirectToAction("Index", "Home");
        }
        // GET: Work
        public ActionResult Index()
        {
            var opwwork2 = db.Opwwork2.Include(w => w.Authorisation);
            return View(opwwork2.ToList());
        }
        public ActionResult WorksforApproval()
        {           
        var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.Pending_Approval);
        return View(Approval.ToList());
        }

        public ActionResult WorksforFunding()
        {
           /* if (db.Opwauthorisation2.ToString() == User_Section.Elective_Works.ToString())
           {*/
               var Funding = db.Opwwork2.Include(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.Pending_Approval);
               return View(Funding.ToList());
           /*}
            if (db.Opwauthorisation2.ToString() == User_Section.Elective_Works.ToString())
            {
                var Funding = db.Opwwork2.Include(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.PendingFunding);
                return View(Funding.ToList());
            }
            else return RedirectToAction("Index");*/
        }

        public ActionResult ApprovalWorks()
        {
            var opwwork2 = db.Opwwork2.Include(w => w.Authorisation);
            return View(opwwork2.ToList());
        }

        // GET: Work/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Opwwork2.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // GET: Work/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name");
            return View();
        }

        // POST: Work/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_ID,Property_ID,User_ID,Proj_Code,Project_Desc,Proj_budget_Requested,Proj_budget_Approved,Proj_funds_issued,Proj_Act_Cost,Status")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Opwwork2.Add(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);
        }

        // GET: Work/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Opwwork2.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);
        }

        // POST: Work/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_ID,Property_ID,User_ID,Proj_Code,Project_Desc,Proj_budget_Requested,Proj_budget_Approved,Proj_funds_issued,Proj_Act_Cost,Status")] Work work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);
        }

        // GET: Work/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Opwwork2.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            return View(work);
        }

        // POST: Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work work = db.Opwwork2.Find(id);
            db.Opwwork2.Remove(work);
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
