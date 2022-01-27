using Accredit_Git_Users_Repository.Models;
using System.Web.Script.Serialization;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Accredit_Git_Users_Repository.Controllers
{
    public class GithubUserController : Controller
    {
        // GET: GithubUser
        [Route("GithubUser/GithubUserResult")]
        public ActionResult GithubUserResult(string githubUserName)
        {
            githubUserName = "robconery";
            var url = "https://api.github.com/users/" + githubUserName;
            Console.WriteLine(url);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "TestApp";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string userData = reader.ReadToEnd();
                    GithubUser userDataResult = (GithubUser)serializer.Deserialize(userData, typeof(GithubUser));
                    return View(userDataResult);
                    //return Json(userDataResult, JsonRequestBehavior.AllowGet);
                }
                //StreamReader readUserData = new StreamReader(response.GetResponseStream());
                //
                //dynamic json = JsonConvert.DeserializeObject(userData);
                //dynamic json = JObject.Parse(userData);                
            }
        }

        // GET: GithubUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GithubUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GithubUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GithubUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GithubUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GithubUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GithubUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
