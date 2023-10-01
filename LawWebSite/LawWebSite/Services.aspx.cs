using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Services : System.Web.UI.Page
    {
        #region Değişkenler
        ServiceController serviceController = new ServiceController();
        ContentController contentController = new ContentController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetServices();
                RenderBody();
            }
        }

        protected void RServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            ReturnModel<Models.Content> GetContentService = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblServices");
            if (!GetContentService.Is_Error)
            {
                LblServices.Text = GetContentService.Model.FirstOrDefault().Description;
                Page.Title = GetContentService.Model.FirstOrDefault().Description;
            }
        }

        private void GetServices()
        {
            ReturnModel<Models.Service> GetServiceList = serviceController.GetServices();
            if (!GetServiceList.Is_Error)
            {
                RServices.DataSource = GetServiceList.Model;
                RServices.DataBind();
            }
        }
    }
}


