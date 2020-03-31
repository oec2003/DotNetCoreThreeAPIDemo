namespace ThreeAPIDemo.Services
{
    public class UserService:IUserService
    {
        public string GetUserName(string userId)
        {
            return $"UserName:{userId}";
        }
    }
}