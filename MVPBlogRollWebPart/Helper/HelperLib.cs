using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace MVPBlogRollWebPart.Helper
{
    public static class HelperLib
    {
        /// <summary>
        /// Check sitename is exist and is a blog site
        /// return false if not.
        /// </summary>
        /// <param name="siteName">URL of site</param>
        /// <returns></returns>
        public static bool CheckSPSiteisABlog(string siteName)
        {
            
            using (SPSite site = new SPSite(siteName))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    if (!web.Exists)
                    {
                        return false;
                    }
                    else
                    {
                        if (web.Lists.TryGetList(HelperConst.Comments) != null && web.Lists.TryGetList(HelperConst.PostList) != null)
                            return true;
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Check if list exist or not in SPweb
        /// </summary>
        /// <param name="web">the request spWeb</param>
        /// <param name="listName">the list need to check</param>
        /// <returns>True: exist / False : not exist</returns>
        public static bool ListExists(SPWeb web, string listName)
        {
            try
            {
                SPList list = web.Lists[listName];
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<string> splitString(string source,params char[]  ch)
        {
            string[] array =  source.Split(ch);
            List<string> mysplit = new List<string>();
            foreach (string sub in array)
            {
                mysplit.Add(sub);
            }

            return mysplit;
        }
    
    }
}
