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
            GetMenus();
            RenderBody();
            GetBlogs();
            GetCommunication();
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

        private void RenderBody()
        {
            var footerModel1 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn1").Model;
            if (footerModel1 != null && footerModel1.Any())
            {
                LblFooterColumn1.Text = footerModel1.FirstOrDefault().Description;
            }

            var footerModel2 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn2").Model;
            if (footerModel2 != null && footerModel2.Any())
            {
                LblFooterColumn2.Text = footerModel2.FirstOrDefault().Description;
            }

            var footerModel3 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn3").Model;
            if (footerModel3 != null && footerModel3.Any())
            {
                LblFooterColumn3.Text = footerModel3.FirstOrDefault().Description;
            }

            var footerModel4 = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn4").Model;
            if (footerModel4 != null && footerModel4.Any())
            {
                LblFooterColumn4.Text = footerModel4.FirstOrDefault().Description;
            }

            var contentModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblCopyright").Model;
            if (contentModel != null && contentModel.Any())
            {
                LblCopyright.Text = contentModel.FirstOrDefault().Description;
            }


            var masterBlogModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblMasterBlog").Model;
            if (masterBlogModel != null && masterBlogModel.Any())
            {
                LblMasterBlog.Text = masterBlogModel.FirstOrDefault().Description;
            }

            var descriptionModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterDescription").Model;
            if (descriptionModel != null && descriptionModel.Any())
            {
                LblFooterDescription.Text = descriptionModel.FirstOrDefault().Description;
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

    }
}