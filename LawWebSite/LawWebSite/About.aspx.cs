using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class About : System.Web.UI.Page
    {
        #region

        ContentController contentController = new ContentController();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderBody();
            }
        }



        private void RenderBody()
        {
            var aboutModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblAbout").Model;
            if (aboutModel != null && aboutModel.Any())
            {
                LblAbout.Text = aboutModel.FirstOrDefault().Description;

                var aboutDetailsModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblAboutUsInformation").Model;
                if (aboutDetailsModel != null && aboutDetailsModel.Any())
                {
                    LblAboutUsInformation.Text = aboutDetailsModel.FirstOrDefault().Description;
                }

            }
        }
    }
}