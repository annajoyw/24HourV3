using ProjectData;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectService
{
    public class CommentService
    {
        private readonly int _commentId;

        public CommentService(int commentId)
        {
            _commentId = commentId;
        }
        //get post comments

        //post comment
        public bool CreateComment(CreateComment model)
        {
            var entity =
                new Comment()
                {
                    CommentId = _commentId,
                    Text = model.
                }
        }
    }
}
