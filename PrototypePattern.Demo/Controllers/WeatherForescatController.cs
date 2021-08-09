using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototypePattern.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForescatController : ControllerBase
    {
        private readonly IUser _user;

        public WeatherForescatController(IUser user)
        {
            _user = user.Clone() as IUser;
        }

        // GET: api/<WeatherForescatController>
        [HttpGet]
        public IUser Get()
        {
            return _user;
        }

     
    }
}
