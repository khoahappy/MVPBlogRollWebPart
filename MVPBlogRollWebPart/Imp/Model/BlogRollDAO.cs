using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using MVPBlogRollWebPart.Helper;
using MVPBlogRollWebPart.Imp.Object;

namespace MVPBlogRollWebPart
{
    public class BlogRollDAO : IBlogRollDAO
    {
        #region Field

        private List<string> _lstblogurl;
        private List<SPList> _lstbloglist;
        private SPList _lstpost;
        
        #endregion

        #region Properties
        /// <summary>
        /// List of valid Blogsites URL
        /// </summary>
        public List<string> ListBlogURL
        {
            get
            {
                return _lstblogurl;
            }
            set
            {
                
                _lstblogurl = getExistSpWeb(value);
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        public List<SPList> ListBlogList
        {
            get
            {

                return ListBlogList;
            }
            set
            {
                _lstbloglist = value;
            }
        }
        public SPList LstPost { get { return _lstpost; } }


        #endregion

        #region Constructor
        /// <summary>
        /// Init Model
        /// </summary>
        /// <param name="urlList">list of urls string</param>
        public BlogRollDAO(List<string> urlList)
        {
            
            this.ListBlogURL = getExistSpWeb(urlList);

            //getSpListPost();
        }
        
        #endregion

        #region Methods

        #region Private Methods

        //Parse all valid Blogsite links to model    
        private List<string> getExistSpWeb(List<string> source)
        {
            List<string> lst = new List<string>();
            foreach (string s in source)
            {
                if (HelperLib.CheckSPSiteisABlog(s))
                {
                   
                    lst.Add(s);
                }
            }
            return lst;
        }



       

        private List<Post> getPost(SPList lst)
        {
            List<Post> lstPost = new List<Post>();
            foreach (SPListItem spli in lst.Items)
            {
                Post p = new Post(spli, lst.ParentWeb);
                
                lstPost.Add(p);
            }

            return lstPost;

        }

        

        


        private void getSpListPost()
        {
            foreach (string str in _lstblogurl)
            {

                SPSite oSiteCollection = SPContext.Current.Site;
                SPList oList = oSiteCollection.AllWebs[str].Lists[HelperConst.PostList];
                this._lstbloglist.Add(oList);
            }
        }

        private List<SPListItemCollection> getPostCollection(int n)
        {
            List<SPListItemCollection> myPostCollection = new List<SPListItemCollection>();
            foreach (SPList spl in _lstbloglist)
            {
                SPQuery myquery = new SPQuery();
                myquery.Query = string.Format(@"<Query>
                                    <Where>
                                            <IsNotNull>
                                                <FieldRef Name='{0}' />
                                            </IsNotNull>
                                    </Where>
                                    <OrderBy><FieldRef Name='{1}' Ascending='False' />
                                    </OrderBy>
                                </Query>", HelperConst.ID, HelperConst.PostPublishedDate);
                myquery.RowLimit = (uint)n;

                myPostCollection.Add(spl.GetItems(myquery));
            }
            return myPostCollection;
        }

        private 

        #endregion

        #region Public Methods

        public void addCommend(Comment comment, Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> getLastestNPost(int n)
        {
            throw new NotImplementedException();

           

           
            
            

        }

        public Post getPostById(int id)
        {
            throw new NotImplementedException();
        }

        public void init()
        {
            throw new NotImplementedException();
        }

        public void savePost()
        {
            throw new NotImplementedException();
        }

        public void updatePost()
        {
            throw new NotImplementedException();
        }

        public void insertPost()
        {
            throw new NotImplementedException();
        }

        public void setURLList()
        {
            throw new NotImplementedException();
        }

        
        #endregion

        #endregion
      
    }
}
