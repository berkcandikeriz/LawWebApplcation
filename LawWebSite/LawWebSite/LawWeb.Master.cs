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
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            GetMenus();
            RenderBody();
            GetLawyers();
            GetBlogs();
        }

        private void GetBlogs()
        {
            ReturnModel<Models.Blog> GetBlogList = blogController.GetBlogsByLanguageId(Global.GlobalLanguage.LanguageId);

            if (!GetBlogList.Is_Error)
            {
                RMasterBlogs.DataSource = GetBlogList.Model.Take(6).ToList();
                RMasterBlogs.DataBind();
            }
        }

        private void GetLawyers()
        {
            ReturnModel<Lawyer> GetLawyerList = lawyerController.GetLawyers();
            if (!GetLawyerList.Is_Error)
            {
                RMasterOurTeam.DataSource = GetLawyerList.Model;
                RMasterOurTeam.DataBind();
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

            var masterTeamModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblMasterOurTeam").Model;
            if (masterTeamModel != null && masterTeamModel.Any())
            {
                LblMasterOurTeam.Text = masterTeamModel.FirstOrDefault().Description;
            }

            var descriptionModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterDescription").Model;
            if (descriptionModel != null && descriptionModel.Any())
            {
                LblFooterDescription.Text = descriptionModel.FirstOrDefault().Description;
            }

            var servicesModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterOurServices").Model;
            if (servicesModel != null && servicesModel.Any())
            {
                LblFooterOurServices.Text = servicesModel.FirstOrDefault().Description;
            }

            var aboutModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterAboutMe").Model;
            if (aboutModel != null && aboutModel.Any())
            {
                LblFooterAboutMe.Text = aboutModel.FirstOrDefault().Description;
            }

            var blogModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterBlog").Model;
            if (blogModel != null && blogModel.Any())
            {
                LblFooterBlog.Text = blogModel.FirstOrDefault().Description;
            }

            var teamModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterOurTeam").Model;
            if (teamModel != null && teamModel.Any())
            {
                LblFooterOurTeam.Text = teamModel.FirstOrDefault().Description;
            }
        }


        private void GetMenus()
        {
            RMenus.DataSource = menuController.GetMenusByLanguageId(Global.GlobalLanguage.LanguageId).Model;
            RMenus.DataBind();
        }
    }
}