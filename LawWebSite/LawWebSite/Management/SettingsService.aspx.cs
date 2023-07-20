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
    public partial class SettingsService : System.Web.UI.Page
    {
        ServiceController serviceController = new ServiceController();
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetServices();
                GetLanguagesByDdlServiceDilSeciniz();
            }
        }

        private void GetLanguagesByDdlServiceDilSeciniz()
        {

            var dilListesi = languageController.GetLanguages();
            DdlServiceDilSeciniz.Items.Clear();
            DdlServiceDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlServiceDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });

                }
            }
        }

        private void GetServices()
        {
            var getServiceModel = serviceController.GetServices();
            if (!getServiceModel.Is_Error)
            {
                var sortedServices = getServiceModel.Model.OrderBy(m => m.CreatedDate).ToList();
                RServices.DataSource = sortedServices;
                RServices.DataBind();
            }
        }

        private void Clear()
        {
            DdlServiceDilSeciniz.SelectedIndex = 0;
            txtServiceAdi.Text = string.Empty;
            txtServiceAciklama.Text = string.Empty;
            txtServiceUrl.Text = string.Empty;
            txtServiceGorselLinki.Text = string.Empty;
        }

        protected void lnkAddService_Click(object sender, EventArgs e)
        {
            if (Session["selectedServiceItem"] != null)
            {
                Models.Service selectedServiceItem = Session["selectedServiceItem"] as Models.Service;
                Models.Service newService = new Models.Service()
                {
                    ServiceId = selectedServiceItem.ServiceId,
                    LanguageId = int.Parse(DdlServiceDilSeciniz.SelectedValue),
                    Title = txtServiceAdi.Text,
                    Image = txtServiceGorselLinki.Text,
                    Description = txtServiceAciklama.Text,
                    Url = txtServiceUrl.Text,
                    CreatedDate = selectedServiceItem.CreatedDate,
                    UpdateDate = DateTime.Now
                };

                var result = serviceController.UpdateService(newService);

                if (!result.Is_Error)
                {
                    LblServiceModalHeader.Text = "Hizmet Güncelleme Başarılı";
                    LblServiceModalBody.Text = "Hizmet başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalServiceInformation();", true);

                    GetServices();
                    Clear();
                    Session["selectedServiceItem"] = null;
                }
                else
                {
                    LblServiceModalHeader.Text = "Hizmet Güncelleme Başarısız";
                    LblServiceModalBody.Text = "Hizmet güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalServiceInformation();", true);
                }
            }
            else
            {
                Models.Service newService = new Models.Service()
                {
                    LanguageId = int.Parse(DdlServiceDilSeciniz.SelectedValue),
                    Title = txtServiceAdi.Text,
                    Description = txtServiceAciklama.Text,
                    Url = txtServiceUrl.Text,
                    Image = txtServiceGorselLinki.Text,
                    CreatedDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                var result = serviceController.InsertService(newService);

                if (!result.Is_Error)
                {
                    LblServiceModalHeader.Text = "Hizmet Ekleme Başarılı";
                    LblServiceModalBody.Text = "Hizmet başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalServiceInformation();", true);

                    GetServices();
                    Clear();
                }
                else
                {
                    LblServiceModalHeader.Text = "Hizmet Ekleme Başarısız";
                    LblServiceModalBody.Text = "Hizmet eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalServiceInformation();", true);
                }
            }
        }

        protected void LbServiceLanguageEdit_Click(object sender, EventArgs e)
        {
            string serviceId = ((LinkButton)sender).CommandArgument;
            var result = serviceController.GetServiceByServiceId(int.Parse(serviceId));
            LblServiceAddEditHeader.Text = serviceId + "# Numaralı Hizmeti Güncelle";
            lnkAddService.Text = "Hizmeti Güncelle";

            if (!result.Is_Error)
            {
                Models.Service selectedServiceItem = result.Model[0];
                DdlServiceDilSeciniz.SelectedValue = selectedServiceItem.LanguageId.ToString();
                txtServiceAdi.Text = selectedServiceItem.Title;
                txtServiceAciklama.Text = selectedServiceItem.Description;
                txtServiceUrl.Text = selectedServiceItem.Url;
                txtServiceGorselLinki.Text = selectedServiceItem.Image;

                Session["selectedServiceItem"] = selectedServiceItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbServiceEdit();", true);
            }
        }

        protected void LbServiceLanguageDelete_Click(object sender, EventArgs e)
        {
            string serviceId = (sender as LinkButton).CommandArgument;

            var result = serviceController.DeleteService(serviceId);

            if (!result.Is_Error)
            {
                GetServices();

                LblServiceModalHeader.Text = "Hizmet Silme Başarılı";
                LblServiceModalBody.Text = "Hizmet silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalServiceInformation();", true);
            }
            else
            {
                LblServiceModalHeader.Text = "Hizmet Silme Başarısız";
                LblServiceModalBody.Text = "Hizmet silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalServiceInformation();", true);
            }
        }

        protected void LbServiceEkle_Click(object sender, EventArgs e)
        {
            LblServiceAddEditHeader.Text = "Yeni Hizmet Ekle";
            lnkAddService.Text = "Yeni Hizmet Ekle";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbServiceEdit();", true);

        }
    }
}