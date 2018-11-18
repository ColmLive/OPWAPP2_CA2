using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPWAPP2.DAL;
using OPWAPP2.Models;

namespace OPWAPP2.Controllers
{
    public class AuthorisationController : Controller
    {
        private OPWContext2 db = new OPWContext2();

        // GET: Authorisations
        public ActionResult Index()
        {
            return View(db.Opwauthorisation2.ToList());
        }

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
        public ActionResult Edit([Bind(Include = "User_ID,User_Name,User_Password,Email,Company,Usersect,Usersectcode,User_Approval_Limit,WorkId")] Authorisation authorisation)
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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Authorisation objUser)
        {
            if (ModelState.IsValid)
            {
                using (OPWContext2 Logincontext = new OPWContext2())
                {
                    var obj = db.Opwauthorisation2.Where(a => a.User_Name.Equals(objUser.User_Name) && a.User_Password.Equals(objUser.User_Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.User_ID.ToString();
                        Session["UserName"] = obj.User_Name.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


                                    
        /* public ActionResult login(Authorisation username, Authorisation password)
         {
             if (username == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No Username submitted");
             }
             else if (password == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No password submitted");
             }

             var x = username.ToString();
             var y = password.ToString();
             Authorisation A1 = db.opw_authorisation2.FirstOrDefault(p => p.User_Name.Contains(x));

             if (A1 == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Incorrect UserName submitted, Please try again");
             }
             if (A1.User_Password != y)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Incorrect Password submitted, Please try again");
             }

             return View(A1);
         }
         */










    }
}
