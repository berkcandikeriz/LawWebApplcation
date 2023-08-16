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
        #region Değişkenler
        LawyerController lawyerController = new LawyerController();
        ContentController contentController = new ContentController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLawyers();
                RenderBody();
            }
        }

        protected void ROurTeam_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblExamine = e.Item.FindControl("LblExamine") as Label;

                if (lblExamine != null)
                {
                    ReturnModel<Models.Content> GetContentExamine = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblExamine");

                    if (GetContentExamine != null && !GetContentExamine.Is_Error)
                    {
                        var examineDescription = GetContentExamine.Model.FirstOrDefault().Description;
                        lblExamine.Text = examineDescription;
                    }
                }
            }
        }

        private void RenderBody()
        {
            ReturnModel<Models.Content> GetContentOurLawyers = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblOurLawyers");
            if (!GetContentOurLawyers.Is_Error)
            {
                LblOurLawyers.Text = GetContentOurLawyers.Model.FirstOrDefault().Description;
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