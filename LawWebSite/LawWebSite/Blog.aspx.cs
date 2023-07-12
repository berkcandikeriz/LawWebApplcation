using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
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

        ContentController contentController = new ContentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBlogs();
                RenderBody();
            }
        }

        private void RenderBody()
        {
            var blogModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblBlog").Model;
            if (blogModel != null && blogModel.Any())
            {
                LblBlog.Text = blogModel.FirstOrDefault().Description;
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