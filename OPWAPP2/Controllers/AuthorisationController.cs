using OPWAPP2.DAL;
using OPWAPP2.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OPWAPP2.Areas.HelpPage.ModelDescriptions;
using OPWAPP2.Areas.HelpPage.Models;

namespace OPWAPP2.Controllers
{
    public class AuthorisationController : Controller
    {
        private OPWContext2 db = new OPWContext2();

        /// <summary>
        /// Index of Authorisations.
        /// </summary>
        /// <returns></returns>
        /// GET: Authorisations
        public ActionResult Index()
        {
            return View(db.Opwauthorisation2.ToList());
        }

        /// <summary>
        /// Get Authorisation details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Authorisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // GET: Authorisations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,User_Name,User_Password,Email,Company,Usersect,Usersectcode,User_Approval_Limit,WorkId")] Authorisation authorisation)
        {
            try
            {
                if (authorisation.Usersect == User_Section.MandE_Works)
                {
                    authorisation.Usersectcode = User_Section_Code.E30_ZS_34;
                    authorisation.User_Approval_Limit = 0;
                }
                else if (authorisation.Usersect == User_Section.Elective_Works)
                {
                    authorisation.Usersectcode = User_Section_Code.k00_ZS_34;
                    authorisation.User_Approval_Limit = 0;
                }
                else if (authorisation.Usersect == User_Section.Capital_works)
                {
                    authorisation.Usersectcode = User_Section_Code.J10_ZS_34;
                    authorisation.User_Approval_Limit = 0;
                }
                else if (authorisation.Usersect == User_Section.Storage)

                {
                    authorisation.Usersectcode = User_Section_Code.L00_ZH_34;
                    authorisation.User_Approval_Limit = 0;
                }
                else if (authorisation.Usersect == User_Section.Admin)
                {
                    authorisation.Usersectcode = User_Section_Code.Admin;
                    authorisation.User_Approval_Limit = 999999999;
                }
                else if (authorisation.Usersect == User_Section.Accommodation)
                {
                    authorisation.Usersectcode = User_Section_Code.FMU1;
                    authorisation.User_Approval_Limit = 50000;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            if (ModelState.IsValid)
            {
                db.Opwauthorisation2.Add(authorisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorisation);
        }

        // GET: Authorisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
              return View(authorisation);
        }

        // POST: Authorisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,User_Name,User_Password,Email,Company,Usersect,Usersectcode,User_Approval_Limit,WorkId,approvalStatus")] Authorisation authorisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorisation);
        }

        // GET: Authorisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            if (authorisation == null)
            {
                return HttpNotFound();
            }
            return View(authorisation);
        }

        // POST: Authorisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authorisation authorisation = db.Opwauthorisation2.Find(id);
            db.Opwauthorisation2.Remove(authorisation);
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

        // Login model and redirection to user views (JL)
        [HttpPost]
        public ActionResult Authorise(Authorisation userModel)

      {
            {
                using (OPWContext2 db = new OPWContext2())

                {
                    var userDetails = db.Opwauthorisation2.Where(x => x.User_Name == userModel.User_Name && x.User_Password == userModel.User_Password && x.approvalStatus==ApprovalStatus.Approved).FirstOrDefault();
                    if (userDetails == null)
                    {
                        userModel.LoginErrorMessage = "Wrong username or password.";
                        return View("Index", userModel);
                    }
                   else
                    {
                        Session["userID"] = userDetails.User_ID;
                        Session["userName"] = userDetails.User_Name;
                        //OPW Users
                        if (userDetails.Usersect == User_Section.MandE_Works)
                        {
                            return RedirectToAction("MEDashBoard","Authorisation");
                        }
                        else if (userDetails.Usersect == User_Section.Elective_Works)
                        {
                            return RedirectToAction("EWDashBoard","Authorisation");
                        }
                        else if (userDetails.Usersect == User_Section.Capital_works)
                        {
                            return RedirectToAction("CWDashBoard","Authorisation");
                        }
                        else if (userDetails.Usersect == User_Section.Storage)
                        {
                            return RedirectToAction("StorageDashBoard","Authorisation");
                        }
                        // DEASP Approvers
                        else if (userDetails.Usersect == User_Section.Accommodation)
                        {
                            return RedirectToAction("AccomDashBoard","Authorisation");
                        }
                        else if (userDetails.Usersect == User_Section.Finance)
                        {
                            return RedirectToAction("FinanceDashBoard","Authorisation");
                        }
                        //Adminstrators
                        else if (userDetails.Usersect == User_Section.Admin)
                        {
                            return RedirectToAction("AdminDashBoard", "Authorisation");
                        }
                        return View("Index", userModel);
                    }
                }
            }
        }
              
        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        // OPW Users x 4 types Login View Controllers

        public ActionResult EWDashBoard()
        {
            if (Session["UserID"] != null)
            {
             return View();
            }
            
            return RedirectToAction("Login");
        }


        public ActionResult MEDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        public ActionResult CWDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }
                                 
        public ActionResult StorageDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        // Deasp Users x 2 types Login View Controllers (JL)
        public ActionResult AccomDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        public ActionResult FinanceDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        // Admin Login View Controllers (JL)                            
         public ActionResult AdminDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }

            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Redirect to Open OPWAPP Login page.";

            return RedirectToAction("Index","Home");
        }
    }
}
