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
        ContentController contentController = new ContentController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBlogs();
                RenderBody();
            }
        }

        protected void RMasterBlogs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblReadMore = e.Item.FindControl("LblReadMore") as Label;

                if (lblReadMore != null)
                {
                    ReturnModel<Models.Content> GetContentReadMore = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblReadMore");

                    if (GetContentReadMore != null && !GetContentReadMore.Is_Error)
                    {
                        var readMoreDescription = GetContentReadMore.Model.FirstOrDefault().Description;
                        lblReadMore.Text = readMoreDescription;
                    }
                }
            }
        }

        private void RenderBody()
        {
            ReturnModel<Models.Content> GetContentBlogForm = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblBlog");
            if (!GetContentBlogForm.Is_Error)
            {
                LblBlog.Text = GetContentBlogForm.Model.FirstOrDefault().Description;
                Page.Title = GetContentBlogForm.Model.FirstOrDefault().Description;
            }
        }

        private void GetBlogs()
        {
            ReturnModel<Models.Blog> GetBlogList = blogController.GetBlogsByLanguageId(Global.GlobalLanguage.LanguageId);
            if (!GetBlogList.Is_Error)
            {
                RBlogs.DataSource = GetBlogList.Model;
                RBlogs.DataBind();

            }
        }
    }
}