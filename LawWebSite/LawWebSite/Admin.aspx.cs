using LawWebSite.Common;
using LawWebSite.Controller;
using System;
using System.Web.UI;

namespace LawWebSite
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblErrorMessage.Text = "Admin Paneline Hoş Geldiniz";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            AdminController adminController = new AdminController();
            ReturnModel<Models.Admin> result = adminController.CheckAdminLogin(username, password);

            if (!result.Is_Error)
            {
                // Giriş başarılı, admin paneline yönlendirme işlemi
                Response.Redirect("admin_panel.aspx");
            }
            else
            {
                // Giriş başarısız, hata mesajı gösterme işlemi
                lblErrorMessage.Text = result.Message_Content;
            }
        }
    }
}
