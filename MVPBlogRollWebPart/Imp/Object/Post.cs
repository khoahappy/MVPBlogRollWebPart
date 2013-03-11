using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MVPBlogRollWebPart.Helper;

namespace MVPBlogRollWebPart.Imp.Object
{
    public class Post
    {
        #region Properties

        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime DateModified { get; set; }
        public string Author { get; set; }
        public string PictureURL { get; set; }
        public string PostURL { get; set; }
        public int CommentsCount { get { return Comments.Count; } }
        public List<Comment> Comments { get; set; }

        #endregion

        public Comment Comment
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region Constructor

        public Post(SPListItem spli, SPWeb web)
        {
            try
            {
                if (spli != null)
                {
                    this.Title = spli.GetFormattedValue(HelperConst.Tittle);
                    this.PostID = int.Parse(spli.GetFormattedValue(HelperConst.ID));
                    this.Content = spli.GetFormattedValue(HelperConst.PostContent);
                    this.PublishedDate = (DateTime)spli[HelperConst.PostPublishedDate];
                    this.DateModified = (DateTime)spli[HelperConst.DateModified];
                    this.Author = spli.GetFormattedValue(HelperConst.Author);

                    
                    //need test
                    this.PostURL = new SPFieldUrlValue(spli[HelperConst.URL].ToString()).Url;



                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

      
        #endregion

        #region PrivateMethods

        private string getWebURL(SPWeb web)
        {
            return web.Url;
        }

        #endregion

        #region PublicMethods

        public void getComment(List<Comment> lstComment)
        {
            Comments = new List<Comment>();
            try
            {
                Comments = lstComment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion
    }
}
