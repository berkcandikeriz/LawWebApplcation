using LawWebSite.Common;
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
    public partial class SettingsSlider : System.Web.UI.Page
    {
        SliderController sliderController = new SliderController();
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSliders();
                GetLanguagesByDdlDilSeciniz();
            }
        }

        private void GetLanguagesByDdlDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlSliderDilSeciniz.Items.Clear();
            DdlSliderDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlSliderDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });

                }
            }
        }

        private void GetSliders()
        {
            var getSliderModel = sliderController.GetSliders();
            if (!getSliderModel.Is_Error)
            {
                var sortedSliders = getSliderModel.Model.OrderBy(m => m.SliderId).ToList();
                RSliders.DataSource = sortedSliders;
                RSliders.DataBind();
            }
        }

        private void Temizle()
        {

            DdlSliderDilSeciniz.SelectedIndex = 0;
            txtSliderTitle.Text = string.Empty;
            txtSliderSubtitle.Text = string.Empty;
            txtSliderDescription.Text = string.Empty;
            txtSliderImgUrl.Text = string.Empty;

        }

        protected void lnkAddSlider_Click(object sender, EventArgs e)
        {
            if (Session["selectedSliderItem"] != null)
            {
                Models.Slider selectedSliderItem = Session["selectedSliderItem"] as Models.Slider;
                Models.Slider newSlider = new Models.Slider()
                {
                    SliderId = selectedSliderItem.SliderId,
                    LanguageId = int.Parse(DdlSliderDilSeciniz.SelectedValue),
                    SliderTitle = txtSliderTitle.Text.ToUpper(),
                    SliderSubTitle = txtSliderSubtitle.Text.ToUpper(),
                    SliderDescription = txtSliderDescription.Text,
                    ImageUrl = txtSliderImgUrl.Text,
                };
                var result = sliderController.UpdateSlider(newSlider);

                if (!result.Is_Error)
                {
                    LblSliderModalHeader.Text = "Slide Güncelleme Başarılı";
                    LblSliderModalBody.Text = "Slide başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalSliderInformation();", true);

                    GetSliders();
                    Temizle();
                    Session["selectedSliderItem"] = null;
                }
                else
                {
                    LblSliderModalHeader.Text = "Slide Güncelleme Başarısız";
                    LblSliderModalBody.Text = "Slide güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalSliderInformation();", true);
                }
            }

            else
            {
                Models.Slider newSlider = new Models.Slider()
                {
                    LanguageId = int.Parse(DdlSliderDilSeciniz.SelectedValue),
                    SliderTitle = txtSliderTitle.Text.ToUpper(),
                    SliderSubTitle = txtSliderSubtitle.Text.ToUpper(),
                    SliderDescription = txtSliderDescription.Text,
                    ImageUrl = txtSliderImgUrl.Text,
                };

                var result = sliderController.InsertSlider(newSlider);

                if (!result.Is_Error)
                {
                    LblSliderModalHeader.Text = "Yeni Slide Ekleme Başarılı";
                    LblSliderModalBody.Text = "Yeni Slide başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalSliderInformation();", true);

                    GetSliders();
                    Temizle();
                }
                else
                {
                    LblSliderModalHeader.Text = "Yeni Slide Ekleme Başarısız";
                    LblSliderModalBody.Text = "Yeni Slide eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalSliderInformation();", true);
                }
            }
        }

         protected void lnkCloseSlider_Click(object sender, EventArgs e)
        {

        }

        protected void LbSliderEdit_Click(object sender, EventArgs e)
        {
            string sliderId = ((LinkButton)sender).CommandArgument;
            var result = sliderController.GetSliderBySliderId(int.Parse(sliderId));
            LblSliderAddEditHeader.Text = sliderId + "# Numaralı Slider Güncelle";
            lnkAddSlider.Text = "Slide Güncelle";

            if (!result.Is_Error)
            {
                Models.Slider selectedSliderItem = result.Model[0];
                DdlSliderDilSeciniz.SelectedValue = selectedSliderItem.LanguageId.ToString();
                txtSliderTitle.Text = selectedSliderItem.SliderTitle;
                txtSliderSubtitle.Text = selectedSliderItem.SliderSubTitle;
                txtSliderDescription.Text = selectedSliderItem.SliderDescription;
                txtSliderImgUrl.Text = selectedSliderItem.ImageUrl;

                Session["selectedSliderItem"] = selectedSliderItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbSliderEditModal();", true);
            }
        }

        protected void LbSliderDelete_Click(object sender, EventArgs e)
        {
            string sliderId = (sender as LinkButton).CommandArgument;

            var result = sliderController.DeleteSlider(sliderId);

            if (!result.Is_Error)
            {
                GetSliders();

                LblSliderModalHeader.Text = "Slide Silme Başarılı";
                LblSliderModalBody.Text = "Slide silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalSliderInformation();", true);
            }
            else
            {
                LblSliderModalHeader.Text = "Slide Silme Başarısız";
                LblSliderModalBody.Text = "Slide silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalSliderInformation();", true);
            }
        }

        protected void LbSliderEkle_Click(object sender, EventArgs e)
        {
            LblSliderAddEditHeader.Text = "Yeni Slide Ekle";
            lnkAddSlider.Text = "Yeni Slide Ekle";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbSliderEditModal();", true);

        }
    }
}