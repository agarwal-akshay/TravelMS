using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TravelMS.Filters;
using TravelMS.Models;

namespace TravelMS.Controllers
{
    public class AdminPanelController : Controller
    {
        //
        // GET: /AdminPanel/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult lockedAccounts()
        {
            List<RegisterModel> modelList = AdminPanelBizLayer.lockedAccounts();
            return View(modelList);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult lockedAccounts(List<RegisterModel> modelList, string User_ID)
        {
            var res = AdminPanelBizLayer.unlockAccount(User_ID);
            ModelState.Clear();
            List<RegisterModel> updatedmodelList = AdminPanelBizLayer.lockedAccounts();
            return View(updatedmodelList);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult reset()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult settle()
        {
            return View();
        }
        [Authorize]
        public ActionResult closedRequests()
        {
            return View();
        }

        [Authorize]
        public ActionResult addAgent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addAgent(AgentModel model)
        {
            if (ModelState.IsValid)
            {
                var res = AdminPanelBizLayer.addAgent(model);
            }
            ModelState.Clear();
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult manageAgent()
        {
            return View();
        }
    }
}
