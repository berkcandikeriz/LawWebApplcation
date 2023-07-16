using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsBlog : System.Web.UI.Page
    {
        BlogController blogController = new BlogController();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetBlogs();

        }

        private void GetBlogs()
        {
            var getBlogModel = blogController.GetBlogs();
            if (!getBlogModel.Is_Error)
            {
                var sortedBlogs = getBlogModel.Model.OrderBy(m => m.CreatedDate).ToList();
                RBlogs.DataSource = sortedBlogs;
                RBlogs.DataBind();
            }
        }

        protected void lnkAddBlog_Click(object sender, EventArgs e)
        {
            Models.Blog newBlog = new Models.Blog()
            {
                LanguageId = int.Parse(txtBlogDilId.Text),
                BlogTitle = txtBlogAdi.Text,
                BlogSubtitle = txtBlogAltBaslik.Text,
                Description = txtBlogAciklama.Text,
                Author = txtBlogYazar.Text,
                Url = txtBlogUrl.Text,
                ImageUrl = txtBlogGorselLinki.Text,
                CreatedDate = DateTime.Today,
                UpdateDate = DateTime.Today
            };

            var result = blogController.InsertBlog(newBlog);

            if (!result.Is_Error)
            {
                GetBlogs();

                txtBlogDilId.Text = string.Empty;
                txtBlogAdi.Text = string.Empty;
                txtBlogAltBaslik.Text = string.Empty;
                txtBlogAciklama.Text = string.Empty;
                txtBlogYazar.Text = string.Empty;
                txtBlogUrl.Text = string.Empty;
                txtBlogGorselLinki.Text = string.Empty;

            }
            else
            {
                // Hata durumunda uygun işlemleri gerçekleştirin
            }
        }

        protected void lnkCloseBlog_Click(object sender, EventArgs e)
        {

        }
        protected void lnkDeleteBlog_Click(object sender, EventArgs e)
        {
            string blogId = (sender as LinkButton).CommandArgument;

          
            var result = blogController.DeleteBlog(blogId);

            if (!result.Is_Error)
            {
                string successMessage = "Blog başarıyla silindi.";
                GetBlogs();
            }
            else
            {
        

            
                string errorMessage = "Silme işlemi başarısız oldu. Lütfen tekrar deneyin.";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DeleteError", $"alert('{errorMessage}');", true);

              

              
            }
        }






    }
}