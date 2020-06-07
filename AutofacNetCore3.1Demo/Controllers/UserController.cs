using AutofacNetCore3._1Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutofacNetCore3._1Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IDeptService _deptService;
        // public IUserService UserService { get; set; }

       public UserController(IUserService userService,IDeptService deptService)
       {
           _userService = userService;
           _deptService = deptService;
       }
        public string GetUserName()
        {
            return $"{_userService.GetUserName()}({_deptService.GetDeptName()})";
            //return UserService.GetUserName();
        }
    }
}