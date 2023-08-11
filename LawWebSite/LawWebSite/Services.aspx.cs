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
    
        private void RenderBody()
        {
            var serviceModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblServices").Model;
            if (serviceModel != null && serviceModel.Any())
            {
                LblServices.Text = serviceModel.FirstOrDefault().Description;
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

        
       