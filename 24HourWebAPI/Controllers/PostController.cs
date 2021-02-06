using Microsoft.AspNet.Identity;
using ProjectModels;
using ProjectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourWebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        //get post
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPost();
            return Ok(posts);
        }
        //post post
        public IHttpActionResult Post(CreatePost post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
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
