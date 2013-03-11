using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPBlogRollWebPart
{
    public interface IBlogRollPresenter
    {
        IBlogRollDAO BlogRollDAO
        {
            get;
            set;
        }

        IBlogRollView BlogRollView
        {
            get;
            set;
        }

        int PostNum
        {
            get;
            set;
        }

        bool AvatarVisible
        {
            get;
            set;
        }

        int WordPerPost
        {
            get;
            set;
        }

        void commend();

        void initView();

        void initModel();

        void newPost();

        void pushPostToView();

        void refresh();

        void setBlogProperty();
    }
}
