using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectModels;

using System.Threading.Tasks;


namespace ProjectService
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService (Guid userId)
	    {
             _userId = userId;
	    }

        
        //Create Post
        public bool CreatePost(CreatePost model)
        {

        }
        
         
        //Get POst
        
    }
}
