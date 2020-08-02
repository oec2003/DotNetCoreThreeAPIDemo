using System.Collections.Generic;
using ExceptionDemo.Models;

namespace ExceptionDemo.Services
{
    public interface IUserService
    {
        string GetUserName(int id);

        List<User> GetAllUsers();
        List<User> FindUsers(string name);
        User AddUser(User user);
        string GetFullName(int id);
        User GetUserById(int id);
    }
}