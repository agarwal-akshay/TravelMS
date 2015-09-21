using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMS.Filters;
using TravelMS.Models;

namespace TravelMS.Controllers
{
    //[Authorize]
    //[InitializeSimpleMembership]
    public class AdminPanelController : Controller
    {
        //
        // GET: /AdminPanel/

        public ActionResult Index(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            return View();
        }
        public ActionResult lockedAccounts(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            ViewBag.lockedAccounts = AdminPanelBizLayer.lockedAccounts();
            return View();
        }
        public ActionResult reset(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            return View();
        }
        public ActionResult settle(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            return View();
        }
        public ActionResult closedRequests(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            return View();
        }
        public ActionResult addAgent(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            return View();
        }
        public ActionResult manageAgent(LoginModel model)
        {
            ViewBag.User_ID = model.UserName;
            return View();
        }
    }
}
