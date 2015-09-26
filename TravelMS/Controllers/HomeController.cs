using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelMS.Filters;
using WebMatrix.WebData;

namespace TravelMS.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                string[] role = Roles.GetRolesForUser();
                switch (role[0])
                {
                    case "Emp": return RedirectToAction("Index", "Employee");
                    case "Admin": return RedirectToAction("Index", "AdminPanel");
                    case "Agent": return RedirectToAction("Index", "Agent");
                }
            }
            return View();
        }
    }
}