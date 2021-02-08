using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectModels;

using System.Threading.Tasks;
using ProjectData;

namespace ProjectService
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(CreatePost model)
        {
            var entity = new Post()
            {
                UserId = _userId,
                Title = model.Title,
                Text = model.Text,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get Post

        public IEnumerable<PostListItem> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                         .Posts
                         .Where(e => e.UserId == _userId)
                         .Select(
                             e =>
                                 new PostListItem
                                 {
                                     PostId = e.PostId,
                                     Title = e.Title,
                                     CreatedUtc = e.CreatedUtc
                                 }
                         );
                return query.ToArray();
            }
        }

    }
}
