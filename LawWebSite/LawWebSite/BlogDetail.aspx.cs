using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class BlogDetail : System.Web.UI.Page
    {
        BlogController blogController = new BlogController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["BlogDetailContent"]))
                {
                    int BlogId = 0;
                    if (int.TryParse(Request.QueryString["BlogDetailContent"], out BlogId))
                    {
                        var result = blogController.GetBlogByBlogId(BlogId);
                        if (!result.Is_Error)
                        {
                            var SelectedBlog = result.Model[0];
                            Page.Title = LblBlogHeader.Text = SelectedBlog.BlogTitle;
                            LblBlogSubTitle.Text = SelectedBlog.BlogSubtitle;
                            LblCreatedDate.Text = SelectedBlog.CreatedDate.ToString("d");
                            LblAuthor.Text = SelectedBlog.Author;
                            LblBlogContent.Text = SelectedBlog.Description;

                            if (!string.IsNullOrEmpty(SelectedBlog.ImageUrl.Trim()) && SelectedBlog.ImageUrl.Trim() != "#")
                            {
                                if (SelectedBlog.ImageUrl.Contains("http"))
                                {
                                    ImgImageUrl.ImageUrl = SelectedBlog.ImageUrl;
                                }
                                else
                                {
                                    ImgImageUrl.ImageUrl = "/Assets/Uploads/" + SelectedBlog.ImageUrl;
                                }
                            }
                            else
                            {
                                ImgImageUrl.ImageUrl = "Assets/images/image_1.jpg";
                            }
                        }
                    }
                }
            }
        }
    }
}