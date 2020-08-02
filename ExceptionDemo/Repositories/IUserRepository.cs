using System;
using System.Collections.Generic;
using ExceptionDemo.Models;

namespace ExceptionDemo.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User AddUser(User user);
    }
}