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
    public partial class LawWeb : System.Web.UI.MasterPage
    {
        #region Değişkenler
        LawyerController lawyerController = new LawyerController();
        MenuController menuController = new MenuController();
        ContentController contentController = new ContentController();
        BlogController blogController = new BlogController();
        CommunicationController communicationController = new CommunicationController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenus();
                RenderBody();
                GetBlogs();
                GetCommunication();
            }
           
        }

        private void GetBlogs()
        {
            ReturnModel<Models.Blog> GetBlogList = blogController.GetBlogsByLanguageId(Global.GlobalLanguage.LanguageId);

            if (!GetBlogList.Is_Error)
            {
                var sortedBlogs = GetBlogList.Model
            .Where(m => m.OrderNumber.HasValue)
            .OrderBy(m => m.OrderNumber)
            .Take(3)
            .ToList();

                RMasterBlogs.DataSource = sortedBlogs;
                RMasterBlogs.DataBind();
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
            ReturnModel<Models.Content> GetContentFooterModel1 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn1");
            if (!GetContentFooterModel1.Is_Error)
            {
                LblFooterColumn1.Text = GetContentFooterModel1.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentFooterModel2 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn2");
            if (!GetContentFooterModel2.Is_Error)
            {
                LblFooterColumn2.Text = GetContentFooterModel2.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentFooterModel3 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn3");
            if (!GetContentFooterModel3.Is_Error)
            {
                LblFooterColumn3.Text = GetContentFooterModel3.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentFooterModel4 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn4");
            if (!GetContentFooterModel4.Is_Error)
            {
                LblFooterColumn4.Text = GetContentFooterModel4.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentCopyright = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblCopyright");
            if (!GetContentCopyright.Is_Error)
            {
                LblCopyright.Text = GetContentCopyright.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentMasterBlog = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblMasterBlog");
            if (!GetContentMasterBlog.Is_Error)
            {
                LblMasterBlog.Text = GetContentMasterBlog.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentFooterDescription = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterDescription");
            if (!GetContentFooterDescription.Is_Error)
            {
                LblFooterDescription.Text = GetContentFooterDescription.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentFooterMail = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterMail");
            if (!GetContentFooterMail.Is_Error)
            {
                LblFooterMail.Text = GetContentFooterMail.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentFooterTwitter = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterTwitter");
            if (!GetContentFooterTwitter.Is_Error)
            {
                LblFooterTwitter.Text = GetContentFooterTwitter.Model.FirstOrDefault().Description;
            }
        }

        /// <summary>
        /// Location = 1 ise üstteki menü, Location 2 ise alttaki menü dolar
        /// </summary>
        private void GetMenus()
        {
            RMenus.DataSource = menuController.GetMenusByLanguageId(Global.GlobalLanguage.LanguageId).Model.Where(x => x.Location == 1);
            RMenus.DataBind();

            RMenusBottom.DataSource = menuController.GetMenusByLanguageId(Global.GlobalLanguage.LanguageId).Model.Where(x => x.Location == 2);
            RMenusBottom.DataBind();
        }

        private void GetCommunication()
        {
            ReturnModel<Models.Communication> GetCommunicationList = communicationController.GetCommunicationsByLanguageId(Global.GlobalLanguage.LanguageId);

            if (!GetCommunicationList.Is_Error)
            {
                RCommunication.DataSource = GetCommunicationList.Model;
                RCommunication.DataBind();
            }

        }

        protected string GetLinkFromDatabase(string linkKey)
        {
            var linkModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, linkKey).Model;
            if (linkModel != null && linkModel.Any())
            {
                return linkModel.FirstOrDefault().Description;
            }
            return "#"; // Varsayılan bir link veya boş link
        }

    }
}