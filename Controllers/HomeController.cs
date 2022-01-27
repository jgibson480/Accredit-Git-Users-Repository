using Accredit_Git_Users_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accredit_Git_Users_Repository.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SearchUser(string githubUserName)
        {
            return Json("https://api.github.com/users/robconery");
        }

            
    }
}