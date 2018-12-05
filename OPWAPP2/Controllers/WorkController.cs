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

        // GET: Work
        public ActionResult Index()
      
        { var opwwork2 = db.Opwwork2.Include(w => w.Authorisation);
          return View(opwwork2.ToList());
        }


        // OPW approval lists by section
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

        // DEASP approval lists by section
        public ActionResult AccomWorksforApproval()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.Pending_Approval);
            return View(Approval.ToList());
        }

        public ActionResult FinanceWorksforApproval()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.Pending_Approval);
            return View(Approval.ToList());
        }

        public ActionResult AccomWorksforFunding()
        {
            var Approval = db.Opwwork2.Where(w => w.Status == Status.PendingFunding);
            return View(Approval.ToList());
        }

        public ActionResult FinanceWorksforFunding()
        {
            var Approval = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Status == Status.PendingFunding);
            return View(Approval.ToList());
        }



        // OPW Funding lists by section
        public ActionResult EWWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Elective_Works && w.Status == Status.PendingFunding);
            return View(Funding.ToList());
        }

        public ActionResult MEWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.MandE_Works && w.Status == Status.PendingFunding);
            return View(Funding.ToList());
        }

        public ActionResult CWWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Capital_works && w.Status == Status.PendingFunding);
            return View(Funding.ToList());
        }
        public ActionResult StorageWorksforFunding()
        {
            var Funding = db.Opwwork2.Include(w => w.Authorisation).Where(w => w.Authorisation.Usersect == User_Section.Storage && w.Status == Status.PendingFunding);
            return View(Funding.ToList());
        }



        // Works Status lists by section
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

        // GET: Work/Edit/5
        [HttpGet]
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
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);
        }

        // POST: Work/Edit/5  - Approve Project
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve([Bind(Include = "Status")] Work work)
        {
            if (ModelState.IsValid)
            {
                work.Status = Status.Approved;
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AccomWorksforApproval");
            }
            ViewBag.User_ID = new SelectList(db.Opwauthorisation2, "User_ID", "User_Name", work.User_ID);
            return View(work);
        }


        // POST: Work/Edit/5  - Funding project
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fund([Bind(Include = "Status")] Work work)
        {
            if (ModelState.IsValid)
            {
                work.Status = Status.Funded;
                db.Entry(work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FinanceWorksforFunding");
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
