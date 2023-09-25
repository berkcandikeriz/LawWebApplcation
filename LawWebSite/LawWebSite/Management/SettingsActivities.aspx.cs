using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class SettingsActivities : System.Web.UI.Page
    {
        ActivitiesController activitiesController = new ActivitiesController();
        LanguageController languageController = new LanguageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetActivities();
                GetLanguagesByDdlActivitiesDilSeciniz();
            }
        }

        private void GetLanguagesByDdlActivitiesDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlActivitiesDilSeciniz.Items.Clear();
            DdlActivitiesDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlActivitiesDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });
                }
            }
        }

        private void GetActivities()
        {
            var getActivitiesModel = activitiesController.GetActivities();
            if (!getActivitiesModel.Is_Error)
            {
                var sortedActivities = getActivitiesModel.Model.OrderBy(m => m.ActivitiesId).ToList();
                RActivities.DataSource = sortedActivities;
                RActivities.DataBind();
            }
        }

        private void Clear()
        {
            DdlActivitiesDilSeciniz.SelectedIndex = 0;
            txtActivitiesAdi.Text = string.Empty;
            txtActivitiesAciklama.Text = string.Empty;
            Session["ActivitiesImage"] = null;
            txtActivitiesOrder.Text = string.Empty;
        }

        protected void lnkAddActivities_Click(object sender, EventArgs e)
        {
            if (Session["selectedActivitiesItem"] != null)
            {
                Models.Activity selectedActivitiesItem = Session["selectedActivitiesItem"] as Models.Activity;
                string ActivitiesImage = string.Empty;
                if (Session["ActivitiesImage"] != null)
                {
                    ActivitiesImage = Session["ActivitiesImage"].ToString();
                }

                if (FuActivitiesPhoto.HasFile)
                {
                    string DeleteImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), ActivitiesImage);
                    if (File.Exists(DeleteImagePath))
                        File.Delete(DeleteImagePath);

                    Guid guid = Guid.NewGuid();
                    FileInfo fi = new FileInfo(FuActivitiesPhoto.FileName);
                    string NewImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), guid + fi.Extension);
                    string NewImageName = guid + fi.Extension;

                    FuActivitiesPhoto.SaveAs(NewImagePath);
                    ActivitiesImage = NewImageName;
                }
                Models.Activity newActivities = new Models.Activity()
                {
                    ActivitiesId = selectedActivitiesItem.ActivitiesId,
                    LanguageId = int.Parse(DdlActivitiesDilSeciniz.SelectedValue),
                    BlogTitle = txtActivitiesAdi.Text,
                    Description = txtActivitiesAciklama.Text,
                    ImageUrl = ActivitiesImage,
                    OrderNumber = string.IsNullOrEmpty(txtActivitiesOrder.Text) ? '*' : (int.TryParse(txtActivitiesOrder.Text, out int order) ? order : '*')


                };

                var result = activitiesController.UpdateActivities(newActivities);

                if (!result.Is_Error)
                {
                    LblActivitiesModalHeader.Text = "Faaliyet Güncelleme Başarılı";
                    LblActivitiesModalBody.Text = "Faaliyet başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalActivitiesInformation();", true);

                    GetActivities();
                    Clear();
                    Session["selectedActivitiesItem"] = null;
                }
                else
                {
                    LblActivitiesModalHeader.Text = "Faaliyet Güncelleme Başarısız";
                    LblActivitiesModalBody.Text = "Faaliyet güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalActivitiesInformation();", true);
                }
            }
            else
            {

                string ActivitiesImage = string.Empty;
                if (FuActivitiesPhoto.HasFile)
                {
                    Guid guid = Guid.NewGuid();
                    FileInfo fi = new FileInfo(FuActivitiesPhoto.FileName);
                    string NewImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), guid + fi.Extension);
                    string NewImageName = guid + fi.Extension;
                    FuActivitiesPhoto.SaveAs(NewImagePath);
                    ActivitiesImage = NewImageName;
                }
                else
                {
                    ActivitiesImage = "image_1.jpg";
                }
                Models.Activity newActivities = new Models.Activity()
                {
                    LanguageId = int.Parse(DdlActivitiesDilSeciniz.SelectedValue),
                    BlogTitle = txtActivitiesAdi.Text,
                    Description = txtActivitiesAciklama.Text,
                    ImageUrl = ActivitiesImage,
                    OrderNumber = string.IsNullOrEmpty(txtActivitiesOrder.Text) ? '*' : (int.TryParse(txtActivitiesOrder.Text, out int order) ? order : '*')
                };



                var result = activitiesController.InsertActivities(newActivities);

                if (!result.Is_Error)
                {
                    LblActivitiesModalHeader.Text = "Faaliyet Ekleme Başarılı";
                    LblActivitiesModalBody.Text = "Faaliyet başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalActivitiesInformation();", true);

                    GetActivities();
                    Clear();
                }
                else
                {
                    LblActivitiesModalHeader.Text = "FaaliyetFaaliyet Ekleme Başarısız";
                    LblActivitiesModalBody.Text = "Activities eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalActivitiesInformation();", true);
                }
            }
        }

        protected void LbActivitiesLanguageEdit_Click(object sender, EventArgs e)
        {
            string activitiesId = ((LinkButton)sender).CommandArgument;
            var result = activitiesController.GetActivitiesByActivitiesId(int.Parse(activitiesId));
            LblActivitiesAddEditHeader.Text = activitiesId + "# Numaralı Faaliyeti Güncelle";
            lnkAddActivities.Text = "Faaliye Güncelle";

            if (!result.Is_Error)
            {
                Models.Activity selectedActivitiesItem = result.Model[0];
                DdlActivitiesDilSeciniz.SelectedValue = selectedActivitiesItem.LanguageId.ToString();
                txtActivitiesAdi.Text = selectedActivitiesItem.BlogTitle;
                txtActivitiesAciklama.Text = selectedActivitiesItem.Description;
                Session["ActivitiesImage"] = selectedActivitiesItem.ImageUrl;
                txtActivitiesOrder.Text = selectedActivitiesItem.OrderNumber.ToString();

                Session["selectedActivitiesItem"] = selectedActivitiesItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbActivitiesEdit();", true);
            }
        }

        protected void LbActivitiesLanguageDelete_Click(object sender, EventArgs e)
        {
            string activitiesId = (sender as LinkButton).CommandArgument;

            var result = activitiesController.DeleteActivities(activitiesId);

            if (!result.Is_Error)
            {
                GetActivities();

                LblActivitiesModalHeader.Text = "Faaliyet Silme Başarılı";
                LblActivitiesModalBody.Text = "Faaliyet silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalActivitiesInformation();", true);
            }
            else
            {
                LblActivitiesModalHeader.Text = "Faaliyet Silme Başarısız";
                LblActivitiesModalBody.Text = "Faaliyet silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalActivitiesInformation();", true);
            }
        }

        protected void LbActivitiesEkle_Click(object sender, EventArgs e)
        {
            LblActivitiesAddEditHeader.Text = "Yeni Faaliyet Ekle";
            lnkAddActivities.Text = "Yeni Faaliyet Ekle";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbActivitiesEdit();", true);

        }

    }
}