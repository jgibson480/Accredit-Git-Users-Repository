namespace Accredit_Git_Users_Repository.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string AvatarURL { get; set; }
    }

    public class UserRepos : User
    {
        public int StargazerCount { get; set; }
    }
}
