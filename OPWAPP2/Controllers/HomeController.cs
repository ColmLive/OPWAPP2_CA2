using OPWAPP2.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OPWAPP2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "FAQ page for users";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "OPWAPP contact page.";

            return View();
        }

       
    }
}