using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPBlogRollWebPart
{
    public interface IBlogRollView
    {
        int ListPost
        {
            get;
            set;
        }

        void refresh();

        void showPost();
    }
}
