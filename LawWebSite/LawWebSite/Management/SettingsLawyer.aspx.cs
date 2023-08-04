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
            if (!IsPostBack)
            {
                GetLawyers();
            }

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

        protected void Clear()
        {
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
            DdlAdminSeciniz.SelectedIndex = 0;
            txtLawyerPassword.Text = string.Empty;
        }

        protected void lnkAddLawyer_Click(object sender, EventArgs e)
        {
            if (Session["selectedLawyerItem"] != null)
            {
                Models.Lawyer selectedLawyerItem = Session["selectedLawyerItem"] as Models.Lawyer;

                Models.Lawyer newLawyer = new Models.Lawyer()
                {
                    LawyerId = selectedLawyerItem.LawyerId,
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
                    Description = txtLawyerDescription.Text
                };

                
                if (bool.TryParse(DdlAdminSeciniz.SelectedValue, out bool isAdmin))
                {
                    newLawyer.IsAdmin = isAdmin;
                }
                else
                {
                    newLawyer.IsAdmin = false;
                }

                newLawyer.Password = txtLawyerPassword.Text;

                var result = lawyerController.UpdateLawyer(newLawyer);

                if (!result.Is_Error)
                {
                    LblLawyerModalHeader.Text = "Avukat Güncelleme Başarılı";
                    LblLawyerModalBody.Text = "Avukat başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalLawyerInformation();", true);

                    GetLawyers();
                    Clear();
                    Session["selectedLawyerItem"] = null;
                }
                else
                {
                    LblLawyerModalHeader.Text = "Avukat Güncelleme Başarısız";
                    LblLawyerModalBody.Text = "Avukat güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalLawyerInformation();", true);
                }
            }
            else
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
                    Description = txtLawyerDescription.Text
                };

             
                if (bool.TryParse(DdlAdminSeciniz.SelectedValue, out bool isAdmin))
                {
                    newLawyer.IsAdmin = isAdmin;
                }
                else
                {
                    newLawyer.IsAdmin = false;
                }

                newLawyer.Password = txtLawyerPassword.Text;

                var result = lawyerController.InsertLawyer(newLawyer);

                if (!result.Is_Error)
                {
                    LblLawyerModalHeader.Text = "Avukat Ekleme Başarılı";
                    LblLawyerModalBody.Text = "Avukat başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalLawyerInformation();", true);

                    GetLawyers();
                    Clear();
                }
                else
                {
                    LblLawyerModalHeader.Text = "Avukat Ekleme Başarısız";
                    LblLawyerModalBody.Text = "Avukat eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalLawyerInformation();", true);
                }
            }
        }



        protected void LbLawyerEdit_Click(object sender, EventArgs e)
        {
            string lawyerId = ((LinkButton)sender).CommandArgument;
            var result = lawyerController.GetLawyerByLawyerId(int.Parse(lawyerId));
            LblLawyerAddEditHeader.Text = lawyerId + "# Numaralı Avukat Güncelle";
            lnkAddLawyer.Text = "Avukat Güncelle";

            if (!result.Is_Error)
            {
                Models.Lawyer selectedLawyerItem = result.Model[0];

                txtLawyerName.Text = selectedLawyerItem.FirstName;
                txtLawyerSurname.Text = selectedLawyerItem.LastName;
                txtLawyerTitle.Text = selectedLawyerItem.Title;
                txtLawyerImage.Text = selectedLawyerItem.ImgUrl;
                txtLawyerFacebook.Text = selectedLawyerItem.Facebook;
                txtLawyerTwitter.Text = selectedLawyerItem.Twitter;
                txtLawyerInstgram.Text = selectedLawyerItem.Instagram;
                txtLawyerLinkedln.Text = selectedLawyerItem.Linkedin;
                txtLawyerEmail.Text = selectedLawyerItem.Email;
                txtLawyerTel.Text = selectedLawyerItem.PhoneNumber;
                txtLawyerDescription.Text = selectedLawyerItem.Description;
                DdlAdminSeciniz.SelectedValue = selectedLawyerItem.IsAdmin.ToString();
                txtLawyerPassword.Text = selectedLawyerItem.Password;

                Session["selectedLawyerItem"] = selectedLawyerItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbLawyerEditModal();", true);
            }
        }

        protected void LbLawyerDelete_Click(object sender, EventArgs e)
        {
            string lawyerId = (sender as LinkButton).CommandArgument;

            var result = lawyerController.DeleteLawyer(lawyerId);

            if (!result.Is_Error)
            {
                GetLawyers();

                LblLawyerModalHeader.Text = "Avukat Silme Başarılı";
                LblLawyerModalBody.Text = "Avukat silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalLawyerInformation();", true);
            }
            else
            {
                LblLawyerModalHeader.Text = "Avukat Silme Başarısız";
                LblLawyerModalBody.Text = "Avukat silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalLawyerInformation();", true);
            }
        }

        protected void LbLawyerEkle_Click(object sender, EventArgs e)
        {
            LblLawyerAddEditHeader.Text = "Yeni Avukat Ekle";
            lnkAddLawyer.Text = "Yeni Avukat Ekle";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbLawyerEditModal();", true);

        }


    }
}