using Microsoft.AspNetCore.Mvc;

namespace InjectDemo.Controllers
{  
    [ApiController]
    [Route("api/[controller]/{action}")]
    public class UserController
    {
        private IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public string GetUserName()
        {
            return _user.GetUserName();
        }
    }
}