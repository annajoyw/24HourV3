using ProjectData;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService
{
    class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        private readonly int _replyId;
        public ReplyService(int replyId)
        {
            _replyId = replyId;
        }

        //post reply to comment
        public bool CreateReply(CreateReply model)
        {
            var entity =
                new Reply()
                {
                    UserId = _userId,
                    Content = model.Content,
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //get comment replies
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reply
                    //.Where(e => e.UserId = _userId)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            Content = e.Content
                        }
                        );
                return query.ToArray();
            }
        }


    }
}
