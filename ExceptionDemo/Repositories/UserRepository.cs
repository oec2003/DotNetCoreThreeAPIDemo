using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionDemo.Models;

namespace ExceptionDemo.Repositories
{
    public class UserRepository:IUserRepository
    {
        private List<User> _users = new List<User>()
        {
            new User() {Id = 1, Name = "oec2003", Code = "oec2003",ParentId = 1},
            new User() {Id = 2, Name = "oec2004", Code = "oec2004",ParentId = 1},
            new User() {Id = 3, Name = "oec2005", Code = "oec2005",ParentId = 2},
        };
        public User GetUserById(int id)
        {
            return _users.Find(x => x.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User AddUser(User user)
        {
            int id = 1;
            if (_users.Any())
            {
                id=_users.OrderByDescending(x => x.Id).First().Id + 1;
            }
            user.Id = id;
            _users.Add(user);

            return user;
        }
    }
}