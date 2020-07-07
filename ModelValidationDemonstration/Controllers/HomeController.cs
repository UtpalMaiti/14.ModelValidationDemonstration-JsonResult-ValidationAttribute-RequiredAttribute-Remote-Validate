using ModelValidationDemonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelValidationDemonstration.Controllers
{
    public class HomeController : Controller
    {
        private List<string> userlist = new List<string>();

        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            if (ModelState.IsValid)
            {
                //Assume that we have written the code to insert a record into DB
                return View("SuccessMessage");
            }
            return View();
        }

        public JsonResult ValidateName(string Name)
        {
            if (Name.StartsWith("Pr"))
            {
                return Json("Employee Name is already existing", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ValidateByName(string Name)
        {
            if (userlist.IndexOf(Name) >= 0)
            {
                return Json("Employee Name is already existing", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}