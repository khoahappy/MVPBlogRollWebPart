using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPBlogRollWebPart.Imp.Object;
using Microsoft.SharePoint;

namespace MVPBlogRollWebPart
{
    public interface IBlogRollDAO
    {
        List<string> ListBlogURL
        {
            get;
            set;
        }

        List<SPList> ListBlogList
        {
            get;
            set;
        }

        
        /// <summary>
        /// Add a comment to a post
        /// </summary>
        /// <param name="comment">a comment</param>
        void addCommend(Comment comment, Post post);

        List<Post> getLastestNPost(int n);

        Post getPostById(int id);

        void init();

        void savePost();

        void updatePost();

        void insertPost();

        void setURLList();
    }
}
