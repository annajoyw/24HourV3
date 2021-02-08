using ProjectData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _24HourWebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostUser([FromBody] User model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                //store model in the database
                _context.User.Add(model);
                int changeCount = await _context.SaveChangesAsync();

                return Ok("Your user was created!");
            }

            //if model was not valid, reject it
            return BadRequest(ModelState);
        }
    }
}
