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
    public partial class About : System.Web.UI.Page
    {
        #region
        AboutController aboutController = new AboutController();
        ContentController contentController = new ContentController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAbouts();
                RenderBody();
            }
        }

        private void RenderBody()
        {
            var aboutModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblAbout").Model;
            if (aboutModel != null && aboutModel.Any())
            {
                LblAbout.Text = aboutModel.FirstOrDefault().Description;
                Page.Title = aboutModel.FirstOrDefault().Description;
            }
        }

        private void GetAbouts()
        {
            ReturnModel<Models.About> GetAboutList = aboutController.GetAboutsByLanguageId(Global.GlobalLanguage.LanguageId);

            if (!GetAboutList.Is_Error)
            {
                RAbouts.DataSource = GetAboutList.Model;
                RAbouts.DataBind();

                if (!string.IsNullOrEmpty(GetAboutList.Model[0].ImageUrl.Trim()) && GetAboutList.Model[0].ImageUrl.Trim() != "#")
                {
                    if (GetAboutList.Model[0].ImageUrl.Contains("http"))
                    {
                        ImgAboutImageUrl.ImageUrl = GetAboutList.Model[0].ImageUrl;
                    }
                    else
                    {
                        ImgAboutImageUrl.ImageUrl = "Assets/Uploads/" + GetAboutList.Model[0].ImageUrl;
                    }
                }
                else
                {
                    ImgAboutImageUrl.ImageUrl = "Assets/images/aile-siddet.jpg";
                }
            }
        }

    }
}
