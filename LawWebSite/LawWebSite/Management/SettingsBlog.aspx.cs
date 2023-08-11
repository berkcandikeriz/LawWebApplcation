using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsBlog : System.Web.UI.Page
    {
        BlogController blogController = new BlogController();
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBlogs();
                GetLanguagesByDdlDilSeciniz();
            }
        }

        private void GetLanguagesByDdlDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlDilSeciniz.Items.Clear();
            DdlDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });
                }
            }
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

        private void Clear()
        {
            DdlDilSeciniz.SelectedIndex = 0;
            txtBlogAdi.Text = string.Empty;
            txtBlogAltBaslik.Text = string.Empty;
            txtBlogAciklama.Text = string.Empty;
            txtBlogYazar.Text = string.Empty;
            Session["BlogImage"] = null;
            txtBlogOrder.Text = string.Empty;
        }

        protected void lnkAddBlog_Click(object sender, EventArgs e)
        {
            if (Session["selectedBlogItem"] != null)
            {
                Models.Blog selectedBlogItem = Session["selectedBlogItem"] as Models.Blog;
                string BlogImage = string.Empty;
                if (Session["BlogImage"] != null)
                {
                    BlogImage = Session["BlogImage"].ToString();
                }

                if (FuBlogPhoto.HasFile)
                {
                    string DeleteImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), BlogImage);
                    if (File.Exists(DeleteImagePath))
                        File.Delete(DeleteImagePath);

                    Guid guid = Guid.NewGuid();
                    FileInfo fi = new FileInfo(FuBlogPhoto.FileName);
                    string NewImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), guid + fi.Extension);
                    string NewImageName = guid + fi.Extension;

                    FuBlogPhoto.SaveAs(NewImagePath);
                    BlogImage = NewImageName;
                }
                Models.Blog newBlog = new Models.Blog()
                {
                    BlogId = selectedBlogItem.BlogId,
                    LanguageId = int.Parse(DdlDilSeciniz.SelectedValue),
                    BlogTitle = txtBlogAdi.Text,
                    BlogSubtitle = txtBlogAltBaslik.Text,
                    Description = txtBlogAciklama.Text,
                    Author = txtBlogYazar.Text,
                    Url = "#",
                    ImageUrl = BlogImage,
                    CreatedDate = DateTime.Parse(txtBlogCreatedDate.Text),
                    UpdateDate = DateTime.Now,
                    OrderNumber = string.IsNullOrEmpty(txtBlogOrder.Text) ? '*' : (int.TryParse(txtBlogOrder.Text, out int order) ? order : '*')


                };

                var result = blogController.UpdateBlog(newBlog);

                if (!result.Is_Error)
                {
                    LblModalHeader.Text = "Blog Güncelleme Başarılı";
                    LblModalBody.Text = "Blog başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalInformation();", true);

                    GetBlogs();
                    Clear();
                    Session["selectedBlogItem"] = null;
                }
                else
                {
                    LblModalHeader.Text = "Blog Güncelleme Başarısız";
                    LblModalBody.Text = "Blog güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalInformation();", true);
                }
            }
            else
            {

                string BlogImage = string.Empty;
                if (FuBlogPhoto.HasFile)
                {
                    Guid guid = Guid.NewGuid();
                    FileInfo fi = new FileInfo(FuBlogPhoto.FileName);
                    string NewImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), guid + fi.Extension);
                    string NewImageName = guid + fi.Extension;

                    FuBlogPhoto.SaveAs(NewImagePath);
                    BlogImage = NewImageName;
                }
                else
                {
                    BlogImage = "image_1.jpg";
                }
                Models.Blog newBlog = new Models.Blog()
                {
                    LanguageId = int.Parse(DdlDilSeciniz.SelectedValue),
                    BlogTitle = txtBlogAdi.Text,
                    BlogSubtitle = txtBlogAltBaslik.Text,
                    Description = txtBlogAciklama.Text,
                    Author = txtBlogYazar.Text,
                    Url = "#",
                    ImageUrl = BlogImage,
                    CreatedDate = DateTime.Parse(txtBlogCreatedDate.Text),
                    UpdateDate = DateTime.Now,
                    OrderNumber = string.IsNullOrEmpty(txtBlogOrder.Text) ? '*' : (int.TryParse(txtBlogOrder.Text, out int order) ? order : '*')
                };



                var result = blogController.InsertBlog(newBlog);

                if (!result.Is_Error)
                {
                    LblModalHeader.Text = "Blog Ekleme Başarılı";
                    LblModalBody.Text = "Blog başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalInformation();", true);

                    GetBlogs();
                    Clear();
                }
                else
                {
                    LblModalHeader.Text = "Blog Ekleme Başarısız";
                    LblModalBody.Text = "Blog eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalInformation();", true);
                }
            }
        }

        protected void LbLanguageEdit_Click(object sender, EventArgs e)
        {
            string blogId = ((LinkButton)sender).CommandArgument;
            var result = blogController.GetBlogByBlogId(int.Parse(blogId));
            LblBlogAddEditHeader.Text = blogId + "# Numaralı Blog Güncelle";
            lnkAddBlog.Text = "Blog Güncelle";

            if (!result.Is_Error)
            {
                Models.Blog selectedBlogItem = result.Model[0];
                DdlDilSeciniz.SelectedValue = selectedBlogItem.LanguageId.ToString();
                txtBlogAdi.Text = selectedBlogItem.BlogTitle;
                txtBlogAltBaslik.Text = selectedBlogItem.BlogSubtitle;
                txtBlogAciklama.Text = selectedBlogItem.Description;
                txtBlogYazar.Text = selectedBlogItem.Author;
                Session["BlogImage"] = selectedBlogItem.ImageUrl;
                txtBlogCreatedDate.Text = selectedBlogItem.CreatedDate.ToString();
                txtBlogOrder.Text = selectedBlogItem.OrderNumber.ToString();

                Session["selectedBlogItem"] = selectedBlogItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbEdit();", true);
            }
        }

        protected void LbLanguageDelete_Click(object sender, EventArgs e)
        {
            string blogId = (sender as LinkButton).CommandArgument;

            var result = blogController.DeleteBlog(blogId);

            if (!result.Is_Error)
            {
                GetBlogs();

                LblModalHeader.Text = "Blog Silme Başarılı";
                LblModalBody.Text = "Blog silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalInformation();", true);
            }
            else
            {
                LblModalHeader.Text = "Blog Silme Başarısız";
                LblModalBody.Text = "Blog silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalInformation();", true);
            }
        }

        protected void LbBlogEkle_Click(object sender, EventArgs e)
        {
            LblBlogAddEditHeader.Text = "Yeni Blog Ekle";
            lnkAddBlog.Text = "Yeni Blog Ekle";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbEdit();", true);

        }
    }
}