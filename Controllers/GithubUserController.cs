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
    }
}
