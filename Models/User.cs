namespace Accredit_Git_Users_Repository.Models
{
    public class GithubUser
    {
        public string name { get; set; }
        public string location { get; set; }
        public string avatar_url { get; set; }
    }

    public class UserRepos
    {
        public int stargazercount { get; set; }
    }
}
