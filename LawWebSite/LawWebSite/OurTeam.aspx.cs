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
    public partial class OurTeam : System.Web.UI.Page
    {
        ContentController contentController = new ContentController();

        #region Değişkenler
        LawyerController lawyerController = new LawyerController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLawyers();
                RenderBody();
            }
        }

        private void RenderBody()
        {
            var ourTeamModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblOurLawyers").Model;
            if (ourTeamModel != null && ourTeamModel.Any())
            {
                LblOurLawyers.Text = ourTeamModel.FirstOrDefault().Description;
            }
        }

        private void GetLawyers()
        {
            ReturnModel<Lawyer> GetLawyerList = lawyerController.GetLawyers();
            if (!GetLawyerList.Is_Error)
            {
                ROurTeam.DataSource = GetLawyerList.Model;
                ROurTeam.DataBind();
            }
        }
    }
}