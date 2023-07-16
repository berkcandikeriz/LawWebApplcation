using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsLawyer : System.Web.UI.Page
    {
        LawyerController lawyerController = new LawyerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetLawyers();
        }

        private void GetLawyers()
        {
            var getLawyerModel = lawyerController.GetLawyers();
            if (!getLawyerModel.Is_Error)
            {
                var sortedLawyers = getLawyerModel.Model.OrderBy(m => m.IsAdmin).ToList();
                RLawyers.DataSource = sortedLawyers;
                RLawyers.DataBind();
            }
        }
        protected void lnkAddLawyer_Click(object sender, EventArgs e)
        {
            Models.Lawyer newLawyer = new Models.Lawyer()
            {
               
                FirstName = txtLawyerName.Text,
                LastName = txtLawyerSurname.Text,
                Title = txtLawyerTitle.Text,
                ImgUrl = txtLawyerImage.Text,
                Facebook = txtLawyerFacebook.Text,
                Twitter = txtLawyerTwitter.Text,
                Instagram = txtLawyerInstgram.Text,
                Linkedin = txtLawyerLinkedln.Text,
                Email = txtLawyerEmail.Text,
                PhoneNumber = txtLawyerTel.Text,
                Description = txtLawyerDescription.Text,
                IsAdmin = int.Parse(txtLawyerAdmin.Text) == 1 ? true : false,
                Password = txtLawyerPassword.Text
            };

            var result = lawyerController.InsertLawyer(newLawyer);

            if (!result.Is_Error)
            {
                GetLawyers();
                txtLawyerName.Text = string.Empty;
                txtLawyerSurname.Text = string.Empty;
                txtLawyerTitle.Text = string.Empty;
                txtLawyerImage.Text = string.Empty;
                txtLawyerFacebook.Text = string.Empty;
                txtLawyerTwitter.Text = string.Empty;
                txtLawyerInstgram.Text = string.Empty;
                txtLawyerLinkedln.Text = string.Empty;
                txtLawyerEmail.Text = string.Empty;
                txtLawyerTel.Text = string.Empty;
                txtLawyerDescription.Text = string.Empty;
                txtLawyerAdmin.Text = string.Empty;
                txtLawyerPassword.Text = string.Empty;
            }
            else
            {
                // Hata durumunda uygun işlemleri gerçekleştirin
            }

        }
        protected void lnkCloseLawyer_Click(object sender, EventArgs e)
        {

        }

    }
}