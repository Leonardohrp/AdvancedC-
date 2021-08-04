using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InMemoryCache.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControllers : ControllerBase
    {
        private readonly IUserCache userCache;

        public UsersControllers(IUserCache userCache)
        {
            this.userCache = userCache;
        }

        // GET: api/<UsersControllers>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userCache.GetCachedUsers();
        }
    }
}
