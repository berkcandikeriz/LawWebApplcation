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
                GetAboutImage();
            }
        }

        private void RenderBody()
        {
            var aboutModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblAbout").Model;
            if (aboutModel != null && aboutModel.Any())
            {
                LblAbout.Text = aboutModel.FirstOrDefault().Description;
            }
        }

        private void GetAbouts()
        {
            ReturnModel<Models.About> GetAboutList = aboutController.GetAbouts();

            if (!GetAboutList.Is_Error)
            {
                RAbouts.DataSource = GetAboutList.Model;
                RAbouts.DataBind();
                RAbouts.DataSource = aboutController.GetAboutsByLanguageId(Global.GlobalLanguage.LanguageId).Model;
                RAbouts.DataBind();

            }
        }

        private void GetAboutImage()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["AboutContent"]))
            {
                int AboutId = 0;
                if (int.TryParse(Request.QueryString["AboutContent"], out AboutId))
                {
                    var result = aboutController.GetAboutByAboutId(AboutId);
                    if (!result.Is_Error)
                    {
                        var SelectedAbout = result.Model[0];

                        if (!string.IsNullOrEmpty(SelectedAbout.ImageUrl.Trim()) && SelectedAbout.ImageUrl.Trim() != "#")
                        {
                            if (SelectedAbout.ImageUrl.Contains("http"))
                            {
                                ImgAboutImageUrl.ImageUrl = SelectedAbout.ImageUrl;
                            }
                            else
                            {
                                ImgAboutImageUrl.ImageUrl = "/Assets/Uploads/" + SelectedAbout.ImageUrl;
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

    }
}
