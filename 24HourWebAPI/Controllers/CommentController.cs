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
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //get post comment
        //method below does not return comment for specific post, returns all comments in DB
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Comment> comment = await _context.Comment.ToListAsync();
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostPost([FromBody] Comment model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                //store model in the database
                _context.Comment.Add(model);
                int changeCount = await _context.SaveChangesAsync();

                return Ok("Your comment was created!");
            }

            //if model was not valid, reject it
            return BadRequest(ModelState);
        }
    }
}
