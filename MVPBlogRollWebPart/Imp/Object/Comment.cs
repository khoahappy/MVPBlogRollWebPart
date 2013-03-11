using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MVPBlogRollWebPart.Helper;


namespace MVPBlogRollWebPart.Imp.Object
{
    public class Comment
    {
        #region Properties

        public int CommentID { get; set; }
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Comtents { get; set; }
        public DateTime DateCreated { get; set; }
        #endregion


        public Comment(SPListItem spli, int postId)
        {
            try
            {

                this.CommentID = (int)spli[HelperConst.ID];
                this.PostID = (int)spli[HelperConst.PostID];
                this.Title = spli.GetFormattedValue(HelperConst.Tittle);
                this.Comtents = spli.GetFormattedValue(HelperConst.CommentContent);
                this.DateCreated = (DateTime)spli[HelperConst.DateModified];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
