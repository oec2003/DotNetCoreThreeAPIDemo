using System.Collections.Generic;
using AutofacNetCore2._1Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutofacNetCore2._1Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public string GetUserName()
        {
            return _userService.GetUserName();
        }
    }
}