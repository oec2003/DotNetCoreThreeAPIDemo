namespace ThreeAPIDemo.Services
{
    public interface IUserService
    {
        string GetUserName(string userId);

        bool ValidatePassword(string userName, string password);
    }
}