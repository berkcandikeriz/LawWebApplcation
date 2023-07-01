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
    public partial class Default : System.Web.UI.Page
    {
        #region
        HomeController homeController = new HomeController();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetHomes();
            }
        }

        private void GetHomes()
        {
            ReturnModel<Models.Home> GetHomeList = homeController.GetHomes();

            if (!GetHomeList.Is_Error)
            {
                RHomes.DataSource = GetHomeList.Model;
                RHomes.DataBind();
                RHomes.DataSource = homeController.GetHomesByLanguageId(Global.GlobalLanguage.LanguageId).Model;
                RHomes.DataBind();

            }
        }
    }
}