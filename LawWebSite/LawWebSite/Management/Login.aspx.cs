using LawWebSite.Common;
using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class Login : System.Web.UI.Page
    {

        LawyerController lawyerController = new LawyerController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LbSignIn_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TbUsername.Text) && !string.IsNullOrEmpty(TbPassword.Text))
            {


                string username = TbUsername.Text;
                string password = TbPassword.Text;

                ReturnModel<Models.Lawyer> result = lawyerController.GetLawyer(username, password);

                if (!result.Is_Error)
                {
                    if (result.Model.FirstOrDefault().IsAdmin == true)
                    {
                        // Giriş başarılı, admin paneline yönlendirme işlemi
                        Session["LoginLawyer"] = result.Model.FirstOrDefault();
                        Response.Redirect("~/Management/Logged.aspx");
                    }
                    else
                    {
                        LblInformation.Text = "Kullanıcı adı veya şifreniz doğru fakat yönetici yetkiniz bulunmamakta.";
                        LblInformation.CssClass = "text-danger";
                    }
                }
                else
                {
                    // Giriş başarısız, hata mesajı gösterme işlemi
                    LblInformation.Text = result.Message_Content;
                    LblInformation.CssClass = "text-danger";
                }
            }
            else
            {
                LblInformation.Text = "Kullanıcı adı veya şifre alanı boş geçilemez.";
                LblInformation.CssClass = "text-danger";
            }
        }
    }
}