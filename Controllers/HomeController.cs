using Accredit_Git_Users_Repository.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Accredit_Git_Users_Repository.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("Home/GithubUserResult/{githubUserName}")]
        public ActionResult GithubUserResult(string githubUsername)
        {
            dynamic userModel = new ExpandoObject();
            userModel.User = GithubUserDetails(githubUsername);
            userModel.Repos = GithubUserRepos(githubUsername);
            return View(userModel);
        }

        // GET: GithubUser
        //[Route("Home/GithubUserResult/{githubUserName}")]
        public dynamic GithubUserDetails(string githubUserName)
        {
            string url = "https://api.github.com/users/" + githubUserName;

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "TestApp";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string userData = reader.ReadToEnd();
                    GithubUser userResult = JsonConvert.DeserializeObject<GithubUser>(userData);
                    
                    return userResult;
                }
            }
        }

        public List<UserRepo> GithubUserRepos(string githubUserName)
        {
            var repos = new List<UserRepo>();

            string userRepoUrl = "https://api.github.com/users/" + githubUserName + "/repos";
            HttpWebRequest request = WebRequest.Create(userRepoUrl) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.UserAgent = "TestApp";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {   
                    while (!reader.EndOfStream)
                    {
                        string userData = reader.ReadToEnd();
                        JArray userDataJArray = JArray.Parse(userData);
                        foreach (JObject repoJObject in userDataJArray.Children<JObject>())
                        {
                            repoJObject.ToObject<UserRepo>();
                            string repoString = repoJObject.ToString();

                            UserRepo _userReposResult = JsonConvert.DeserializeObject<UserRepo>(repoString);
                            repos.Add(new UserRepo
                            {
                                name = _userReposResult.name,
                                description = _userReposResult.description,
                                stargazers_count = _userReposResult.stargazers_count
                            });
                        }     
                    }

                    repos.Sort(delegate (UserRepo item1, UserRepo item2)
                    {
                        return item2.stargazers_count.CompareTo(item1.stargazers_count);
                    });

                    return repos;
                }              
            }
        }
    }
}