namespace Accredit_Git_Users_Repository.Models
{
    public class GithubUser
    {
        public string name { get; set; }
        public string location { get; set; }
        public string avatar_url { get; set; }
    }

    public class UserRepo
    {
        public string name { get; set; }
        public string description { get; set; }
        public int stargazers_count { get; set; }
    }
}
