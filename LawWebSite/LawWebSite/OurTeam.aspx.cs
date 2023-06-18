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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLawyers();
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