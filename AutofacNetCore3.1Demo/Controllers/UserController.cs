using AutofacNetCore3._1Demo.Services;
using InjectLib;
using Microsoft.AspNetCore.Mvc;

namespace AutofacNetCore3._1Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IDeptService _deptService;

        private readonly IEngine _engine;
        // public IUserService UserService { get; set; }

       // public UserController(IUserService userService,IDeptService deptService,IEngine engine)
       // {
       //     _userService = userService;
       //     _deptService = deptService;
       //     _engine = engine;
       // }
       
        public UserController(IEngine engine)
        {
            _engine = engine;
        }
        public string GetUserName()
        {
            //_engine.OnLoad();
            return _engine.UserManager.GetUserName();
            //return $"{_userService.GetUserName()}({_deptService.GetDeptName()})";
            //return UserService.GetUserName();
        }
    }
}