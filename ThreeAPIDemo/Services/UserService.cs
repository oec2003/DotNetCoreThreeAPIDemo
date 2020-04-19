namespace ThreeAPIDemo.Services
{
    public class UserService:IUserService
    {
        public string GetUserName(string userId)
        {
            return $"UserName:{userId}";
        }

        public bool ValidatePassword(string userName, string password)
        {
            if (userName == "oec2003" && password == "000000")
            {
                return true;
            }

            return false;
        }
    }
}