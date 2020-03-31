using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ThreeAPIDemo.Controllers
{
    [Route("api/[controller]/{action}")]
    public class BaseController: ControllerBase
    {
        private readonly IMapper _mapper;
        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IMapper Mapper => _mapper;
    }
}