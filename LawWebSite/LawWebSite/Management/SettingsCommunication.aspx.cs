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
    public partial class SettingsCommunication : System.Web.UI.Page
    {
        CommunicationController communicationController = new CommunicationController();
        LanguageController languageController = new LanguageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCommunications();
                GetLanguagesByDdlDilSeciniz();
            }
        }

        private void GetLanguagesByDdlDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlCommunicationDilSeciniz.Items.Clear();
            DdlCommunicationDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlCommunicationDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });
                }
            }
        }

        private void GetCommunications()
        {
            var GetCommunicationsModel = communicationController.GetCommunications();
            if (!GetCommunicationsModel.Is_Error)
            {
                var sortedCommunications = GetCommunicationsModel.Model.OrderBy(m => m.CommunicationId).ToList();
                RCommunications.DataSource = sortedCommunications;
                RCommunications.DataBind();
            }
        }

        private void Clear()
        {
            DdlCommunicationDilSeciniz.SelectedIndex = 0;
            txtCommunicationAdres.Text = string.Empty;
            txtCommunicationMail.Text = string.Empty;
            txtCommunicationTel.Text = string.Empty;
            txtCommunicationMap.Text = string.Empty;
            txtCommunicationHaftaIci.Text = string.Empty;
            txtCommunicationCumartesi.Text = string.Empty;
            txtCommunicationPazar.Text = string.Empty;

        }

        protected void lnkAddCommunication_Click(object sender, EventArgs e)
        {
            if (Session["selectedCommunicationItem"] != null)
            {
                Models.Communication selectedCommunicationItem = Session["selectedCommunicationItem"] as Models.Communication;
                Models.Communication newCommunication = new Models.Communication()
                {
                    CommunicationId = selectedCommunicationItem.CommunicationId,
                    LanguageId = int.Parse(DdlCommunicationDilSeciniz.SelectedValue),
                    Address = txtCommunicationAdres.Text,
                    PhoneNumber = txtCommunicationMail.Text,
                    MapUrl= txtCommunicationMap.Text,
                    Mail = txtCommunicationTel.Text,
                    MidWeek = txtCommunicationHaftaIci.Text,
                    Saturday = txtCommunicationCumartesi.Text,
                    Sunday = txtCommunicationPazar.Text,
                };
                var result = communicationController.UpdateCommunication(newCommunication);

                if (!result.Is_Error)
                {
                    LblModalHeader.Text = "İletişim Güncelleme Başarılı";
                    LblModalBody.Text = "İletişim başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalCommunicationInformation();", true);

                    GetCommunications();
                    Clear();
                    Session["selectedCommunicationItem"] = null;
                }
                else
                {
                    LblModalHeader.Text = "İletişim Güncelleme Başarısız";
                    LblModalBody.Text = "İletişim güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalCommunicationInformation();", true);
                }
            }
        }

        protected void LbCommunicationEdit_Click(object sender, EventArgs e)
        {
            string communicationId = ((LinkButton)sender).CommandArgument;
            var result = communicationController.GetCommunicationByCommunicationId(int.Parse(communicationId));
            LblCommunicationAddEditHeader.Text = " İletişim Bilgilerini Güncelle";
            lnkAddCommunication.Text = "İletişim Bilgilerini Güncelle";

            if (!result.Is_Error)
            {
                Models.Communication selectedCommunicationItem = result.Model[0];
                DdlCommunicationDilSeciniz.SelectedValue = selectedCommunicationItem.LanguageId.ToString();
                txtCommunicationAdres.Text = selectedCommunicationItem.Address;
                txtCommunicationTel.Text = selectedCommunicationItem.PhoneNumber;
                txtCommunicationMap.Text = selectedCommunicationItem.MapUrl;
                txtCommunicationMail.Text = selectedCommunicationItem.Mail;
                txtCommunicationHaftaIci.Text = selectedCommunicationItem.MidWeek;
                txtCommunicationCumartesi.Text = selectedCommunicationItem.Saturday;
                txtCommunicationPazar.Text = selectedCommunicationItem.Sunday;


                Session["selectedCommunicationItem"] = selectedCommunicationItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbCommunicationEditModal();", true);
            }
        }

        protected void LbCommunicationDelete_Click(object sender, EventArgs e)
        {
            string communicationId = (sender as LinkButton).CommandArgument;

            var result = communicationController.DeleteCommunication(communicationId);

            if (!result.Is_Error)
            {
                GetCommunications();

                LblModalHeader.Text = "İletişim Silme Başarılı";
                LblModalBody.Text = "İletişim silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalCommunicationInformation();", true);
            }
            else
            {
                LblModalHeader.Text = "İletişim Silme Başarısız";
                LblModalBody.Text = "İletişim silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalCommunicationInformation();", true);
            }
        }
    }
}