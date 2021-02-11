using ProjectData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _24HourWebAPI.Controllers
{
    public class ReplyController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //get comment reply
        //method below does not return reply for specific post, returns all replies in DB
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Reply> comment = await _context.Reply.ToListAsync();
            return Ok(comment);
        }

        //post reply
        [HttpPost]
        public async Task<IHttpActionResult> PostReply([FromBody] Reply model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                //store model in the database
                _context.Reply.Add(model);
                int changeCount = await _context.SaveChangesAsync();

                return Ok("Your reply was created!");
            }

            //if model was not valid, reject it
            return BadRequest(ModelState);
        }
    }
}
