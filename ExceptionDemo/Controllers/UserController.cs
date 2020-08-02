using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionDemo.Models;
using ExceptionDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExceptionDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class UserController: ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]

        public string GetUserName(int id)
        {
            return _userService.GetUserName(id);
        }
        
        [HttpGet("{name}")]

        public IActionResult FindUsers([FromQuery]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            
            return new MessageResult("测试");

            // var users = _userService.GetAllUsers();
            // return users;
        }

        [HttpGet]
        public List<User> GetAllUser()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost]
        public User AddUser(User user)
        {
            return _userService.AddUser(user);
        }
        
        [HttpGet("{id}")]
        public string GetFullName(int id)
        {
            return _userService.GetFullName(id);
        }
    }
}