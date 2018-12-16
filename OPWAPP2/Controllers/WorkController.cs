using OPWAPP2.DAL;
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

        // Generic Works Index view
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET: Work
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult Index()
      
        { var opwwork2 = db.Opwwork2.Include(w => w.Authorisation);
          return View(opwwork2.ToList());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                                                         OPW - Views
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // OPW - lists of works for approval by section
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult EWWorksforApproval()
        {
        var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.Pending_Approval);
        return View(Approval.ToList());
        }

        public ActionResult MEWorksforApproval()
        {
        var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.MandE_Works && w.Status == Status.Pending_Approval);
        return View(Approval.ToList());
        }

        public ActionResult CWWorksforApproval()
        {
        var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Capital_works && w.Status == Status.Pending_Approval);
        return View(Approval.ToList());
        }
        public ActionResult StorageWorksforApproval()
        {
        var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Storage && w.Status == Status.Pending_Approval);
        return View(Approval.ToList());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //OPW Funding lists by section
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult EWWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.Approved);
            return View(Funding.ToList());
        }

        public ActionResult MEWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.MandE_Works && w.Status == Status.Approved);
            return View(Funding.ToList());
        }

        public ActionResult CWWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Capital_works && w.Status == Status.Approved);
            return View(Funding.ToList());
        }
        public ActionResult StorageWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Storage && w.Status == Status.Approved);
            return View(Funding.ToList());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Works Status lists by section
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult EWWorksStatus()
        {
            var Status = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Elective_Works);
            return View(Status.ToList());
        }

        public ActionResult MEWorksStatus()
        {
            var Status = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.MandE_Works);
            return View(Status.ToList());
        }

        public ActionResult CWWorksStatus()
        {
            var Status = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Capital_works);
            return View(Status.ToList());
        }
        public ActionResult StorageWorksStatus()
        {
            var Status = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Storage);
            return View(Status.ToList());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //OPW Rejected works lists by section
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult EWWorksrejected()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.Rejected);
            return View(Funding.ToList());
        }

        public ActionResult MEWorksRejected()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.MandE_Works && w.Status == Status.Rejected);
            return View(Funding.ToList());
        }

        public ActionResult CWWorksRejected()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Capital_works && w.Status == Status.Rejected);
            return View(Funding.ToList());
        }
        public ActionResult StorageRejected()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Storage && w.Status == Status.Rejected);
            return View(Funding.ToList());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                                                         DEASP - Views
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Accommodation lists of works for approval (all)
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult AccomWorksforApproval()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.Pending_Approval);
            return View(Approval.ToList());
        }

        public ActionResult AccomWorksforFunding()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.Approved);
            return View(Approval.ToList());
        }

        // Views shared by DEASP Accomodation and Finance
        public ActionResult DEASPWorksStatus()
        {
            var Status = db.Opwwork2.Include(w => w.Authorisation);
            return View(Status.ToList());
        }

        public ActionResult DEASPWorksRejected()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.Rejected);
            return View(Approval.ToList());
        }
                                 
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Finance - lists of works for funding (all)
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~   

        public ActionResult FinanceWorksforApproval()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.Pending_Approval);
            return View(Approval.ToList());
        }

        public ActionResult FinanceWorksforFunding()
        {
            var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Status == Status.Approved);
            return View(Approval.ToList());
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                                                         DEASP - Actions Controllers
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET / POST: Work/Edit/5  - Approve Project
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public ActionResult Approve(int? id)
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
            if (ModelState.IsValid)
            {
                work.Status = Status.Approved;
                work.Proj_budget_Approved = work.Proj_budget_Requested;
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AccomWorksforApproval");
            }
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);

        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET / POST: Work/Edit/5  - Reject Works Project
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ActionResult Reject(int? id)
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
            if (ModelState.IsValid)
            {
                work.Status = Status.Rejected;
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AccomWorksforApproval");
            }
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);

        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET / POST: Work/Edit/5  - Fund Project
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [HttpGet]
        public ActionResult Fund(int? id)
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
            if (ModelState.IsValid)
            {
                work.Status = Status.Funded;
                work.Proj_funds_issued = work.Proj_budget_Approved;
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FinanceWorksforFunding");
            }
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);

        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                                                         Admin - CRUD Views
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET: Work/Details/5
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET: Work/Create
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public ActionResult Create()
        {
            ViewBag.User_ID         = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name");
            ViewBag.Property_ID     = new SelectList(db.Opwproperty2, "Property_ID", "OPW_Building_Code", "Address");
             return View();
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // POST: Work/Create
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_ID,Property_ID,User_ID,Proj_Code,Project_Desc,Proj_budget_Requested,Proj_budget_Approved,Proj_funds_issued,Proj_Act_Cost,Status")] Work work)
        {

            try
            {  
                if (ModelState.IsValid)
                
                 {
                    if (work.Proj_budget_Requested < 750)
                    {
                        work.Proj_budget_Approved = work.Proj_budget_Requested;
                        work.Status = Status.Approved;
                    }
                    else
                    {
                        work.Proj_budget_Approved = 0;
                        work.Status = Status.Pending_Approval;
                    }

                    /*
                     * if (work.Proj_budget_Approved > work.Proj_budget_Requested)
                    {
                        ModelState.AddModelError("", "Unable to save changes. Approved cannot be greater than Requested");
                    }
                    */
                    db.Opwwork2.Add(work);
                    db.SaveChanges();
                        
                         if (work.User_ID == 8)
                            {
                            return RedirectToAction("CWDashBoard", "Authorisation");
                            }
                            else if (work.User_ID == 1)
                            {
                            return RedirectToAction("EWDashBoard", "Authorisation");
                            }
                //return RedirectToAction("Index");
                //return Redirect(Request.UrlReferrer.ToString());
                // Can we have just one Create Function - CJC 
                }   
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.User_ID         = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            ViewBag.Property_ID     = new SelectList(db.Opwproperty2, "Property_ID", "OPW_Building_Code", "Address", work.Property_ID);
            return View(work);
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET: Work/Edit/5
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // POST: Work/Edit/5
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // GET: Work/Delete/5
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // POST: Work/Delete/5
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
