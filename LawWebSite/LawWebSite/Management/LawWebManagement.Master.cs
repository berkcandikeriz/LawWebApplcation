using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class LawWebManagement : System.Web.UI.MasterPage
    {
        Models.Lawyer LoginLawyer = new Models.Lawyer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LoginLawyer"] != null)
                {
                    LoginLawyer = Session["LoginLawyer"] as Models.Lawyer;
                    LblNameSurname.Text = LoginLawyer.FirstName + " " + LoginLawyer.LastName;
                }
            }
            
        }

        protected void LbLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Management/Login.aspx");
        }
    }
}