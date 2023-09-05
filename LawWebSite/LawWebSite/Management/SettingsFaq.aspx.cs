using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsFaq : System.Web.UI.Page
    {
        FaqController faqController = new FaqController();
        LanguageController languageController = new LanguageController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFaqs();
                GetLanguagesByDdlFaqDilSeciniz();
            }
        }

        private void GetLanguagesByDdlFaqDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlFaqDilSeciniz.Items.Clear();
            DdlFaqDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlFaqDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });

                }
            }
        }

        private void GetFaqs()
        {
            var getFaqModel = faqController.GetFaqs();
            if (!getFaqModel.Is_Error)
            {
                var sortedFaqs = getFaqModel.Model.OrderBy(m => m.FaqId).ToList();
                RFaqs.DataSource = sortedFaqs;
                RFaqs.DataBind();
            }
        }

        private void Temizle()
        {
            DdlFaqDilSeciniz.SelectedIndex = 0;
            txtFaqQuestion.Text = string.Empty;
            txtFaqAnswer.Text = string.Empty;
            txtFaqUrl.Text = string.Empty;
            Session["FaqImage"] = null;
        }

        protected void lnkAddFaq_Click(object sender, EventArgs e)
        {
            if (Session["selectedFaqItem"] != null)
            {
                Models.Faq selectedFaqItem = Session["selectedFaqItem"] as Models.Faq;
                Models.Faq newFaq = new Models.Faq()
                {
                    FaqId = selectedFaqItem.FaqId,
                    LanguageId = int.Parse(DdlFaqDilSeciniz.SelectedValue),
                    Question = txtFaqQuestion.Text,
                    Answer = txtFaqAnswer.Text,
                    Url = txtFaqUrl.Text,
                   
                };

                var result = faqController.UpdateFaq(newFaq);

                if (!result.Is_Error)
                {
                    LblFaqModalHeader.Text = "Hizmet Güncelleme Başarılı";
                    LblFaqModalBody.Text = "Hizmet başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalFaqInformation();", true);

                    GetFaqs();
                    Temizle();
                    Session["selectedFaqItem"] = null;
                }
                else
                {
                    LblFaqModalHeader.Text = "Hizmet Güncelleme Başarısız";
                    LblFaqModalBody.Text = "Hizmet güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalFaqInformation();", true);
                }
            }
            else
            {
                Models.Faq newFaq = new Models.Faq()
                {
                    LanguageId = int.Parse(DdlFaqDilSeciniz.SelectedValue),
                    Question = txtFaqQuestion.Text,
                    Answer = txtFaqAnswer.Text,
                    Url = txtFaqUrl.Text,
                };

                var result = faqController.InsertFaq(newFaq);

                if (!result.Is_Error)
                {
                    LblFaqModalHeader.Text = "Hizmet Ekleme Başarılı";
                    LblFaqModalBody.Text = "Hizmet başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalFaqInformation();", true);

                    GetFaqs();
                    Temizle();
                }
                else
                {
                    LblFaqModalHeader.Text = "Hizmet Ekleme Başarısız";
                    LblFaqModalBody.Text = "Hizmet eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalFaqInformation();", true);
                }
            }
        }

        protected void LbFaqLanguageEdit_Click(object sender, EventArgs e)
        {
            string faqId = ((LinkButton)sender).CommandArgument;
            var result = faqController.GetFaqByFaqId(int.Parse(faqId));
            LblFaqAddEditHeader.Text = faqId + "# Numaralı Hizmeti Güncelle";
            lnkAddFaq.Text = "Hizmeti Güncelle";

            if (!result.Is_Error)
            {
                Models.Faq selectedFaqItem = result.Model[0];
                DdlFaqDilSeciniz.SelectedValue = selectedFaqItem.LanguageId.ToString();
                txtFaqQuestion.Text = selectedFaqItem.Question;
                txtFaqAnswer.Text = selectedFaqItem.Answer;
                txtFaqUrl.Text = selectedFaqItem.Url;
                Session["selectedFaqItem"] = selectedFaqItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbFaqEdit();", true);
            }
        }

        protected void LbFaqLanguageDelete_Click(object sender, EventArgs e)
        {
            string faqId = (sender as LinkButton).CommandArgument;

            var result = faqController.DeleteFaq(faqId);

            if (!result.Is_Error)
            {
                GetFaqs();

                LblFaqModalHeader.Text = "Hizmet Silme Başarılı";
                LblFaqModalBody.Text = "Hizmet silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalFaqInformation();", true);
            }
            else
            {
                LblFaqModalHeader.Text = "Hizmet Silme Başarısız";
                LblFaqModalBody.Text = "Hizmet silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalFaqInformation();", true);
            }
        }

        protected void LbFaqEkle_Click(object sender, EventArgs e)
        {
            LblFaqAddEditHeader.Text = "Yeni Hizmet Ekle";
            lnkAddFaq.Text = "Yeni Hizmet Ekle";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbFaqEdit();", true);

        }
    }
}