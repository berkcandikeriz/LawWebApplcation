using LawWebSite.Common;
using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Blog : System.Web.UI.Page
    {
        #region
       BlogController blogController = new BlogController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBlogs();
            }
        }

        private void GetBlogs()
        {
            ReturnModel<Models.Blog> GetBlogList = blogController.GetBlogs();

            if (!GetBlogList.Is_Error)
            {
                RBlogs.DataSource = GetBlogList.Model;
                RBlogs.DataBind();
                RBlogs.DataSource = blogController.GetBlogsByLanguageId(Global.GlobalLanguage.LanguageId).Model;
                RBlogs.DataBind();

            }
        }
    }
}