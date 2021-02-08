using Microsoft.AspNet.Identity;
using ProjectData;
using ProjectModels;
using ProjectService;
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
    [Authorize]
    public class PostController : ApiController
    {
        //get post
        //public IHttpActionResult Get()
        //{
        //    PostService postService = CreatePostService();
        //    var posts = postService.GetPost();
        //    return Ok(posts);
        //}

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }

        //post post
        //public IHttpActionResult Post(CreatePost post)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreatePostService();

        //    if (!service.CreatePost(post))
        //        return InternalServerError();

        //    return Ok();
        //}
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostPost([FromBody] Post model)
        {
            if (model is null)
            {
                return BadRequest("Your request body cannot be empty");
            }

            if (ModelState.IsValid)
            {
                //store model in the database
                _context.Posts.Add(model);
                int changeCount = await _context.SaveChangesAsync();

                return Ok("Your post was created!");
            }

            //if model was not valid, reject it
            return BadRequest(ModelState);
        }

        //create post service
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
        
            
    }
}
