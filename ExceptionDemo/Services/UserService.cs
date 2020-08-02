using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionDemo.Common.CustomerException;
using ExceptionDemo.Models;
using ExceptionDemo.Repositories;

namespace ExceptionDemo.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDeptService _deptService;

        public UserService(IUserRepository userRepository,IDeptService deptService)
        {
            _userRepository = userRepository;
            _deptService = deptService;
        }
        public string GetUserName(int id)
        {
            User user=_userRepository.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException($"用户id：{id} 在数据库不存在" );
            }
            return user.Name;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        
        public List<User> FindUsers(string name)
        {
            return _userRepository.GetAllUsers().Where(u=>u.Name.Contains(name)).ToList();
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public string GetFullName(int id)
        {
             try
             {
                User user = GetUserById(id);
                string deptName = _deptService.GetDeptName(user.ParentId);
                //处理其他逻辑
                return $"{user.Name}[{deptName}]";
             }
             catch (Exception e)
             {
                 throw new UserFullNameGenException($"用户 Id 为 {id} 的 FullName 生产失败",e);
                // throw e;
             }
        }

        public User GetUserById(int id)
        {
            User user = _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new UserNotFoundException($"用户id：{id} 在数据库不存在" );
            }

            return user;
        }
    }
}