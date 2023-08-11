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
    public partial class SettingsContent : System.Web.UI.Page
    {
       ContentController contentController = new ContentController();
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetContents();
                GetLanguagesByDdlDilSeciniz();
            }
        }

        private void GetLanguagesByDdlDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlContentDilSeciniz.Items.Clear();
            DdlContentDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlContentDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });
                }
            }
        }

        private void GetContents()
        {
            var getContentModel = contentController.GetContents();
            if (!getContentModel.Is_Error)
            {
                var sortedContents = getContentModel.Model.OrderBy(m => m.ContentId).ToList();
                RContents.DataSource = sortedContents;
                RContents.DataBind();
            }
        }

        private void Temizle()
        {
            DdlContentDilSeciniz.SelectedIndex = 0;
            txtBaslik.Text = string.Empty;
        }

        protected void lnkAddContent_Click(object sender, EventArgs e)
        {
            if (Session["selectedContentItem"] != null)
            {
                Models.Content selectedContentItem = Session["selectedContentItem"] as Models.Content;
                Models.Content newContent = new Models.Content()
                {
                    ContentId = selectedContentItem.ContentId,
                    LanguageId = int.Parse(DdlContentDilSeciniz.SelectedValue),
                    ComponentId = selectedContentItem.ComponentId,
                    Description = txtBaslik.Text,

                };
                var result = contentController.UpdateContent(newContent);

                if (!result.Is_Error)
                {
                    LblContentModalHeader.Text = "İçerik Güncelleme Başarılı";
                    LblContentModalBody.Text = "İçerik başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalContentInformation();", true);

                    GetContents();
                    Temizle();
                    Session["selectedContentItem"] = null;
                }
                else
                {
                    LblContentModalHeader.Text = "İçerik Güncelleme Başarısız";
                    LblContentModalBody.Text = "İçerik güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalContentInformation();", true);
                }
            }
        }

        protected void LbContentEdit_Click(object sender, EventArgs e)
        {
            string contentId = ((LinkButton)sender).CommandArgument;
            var result = contentController.GetContentByContentId(int.Parse(contentId));
            LblContentAddEditHeader.Text = "İçeriği Güncelle";
            lnkAddContent.Text = "İçerik Güncelle";

            if (!result.Is_Error)
            {
                Models.Content selectedContentItem = result.Model[0];
                DdlContentDilSeciniz.SelectedValue = selectedContentItem.LanguageId.ToString();
                txtBaslik.Text = selectedContentItem.Description;
               

                Session["selectedContentItem"] = selectedContentItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbContentEditModal();", true);
            }
        }

        protected void LbContentDelete_Click(object sender, EventArgs e)
        {
            string contentId = (sender as LinkButton).CommandArgument;

            var result = contentController.DeleteContent(contentId);

            if (!result.Is_Error)
            {
                GetContents();

                LblContentModalHeader.Text = "İçerik Silme Başarılı";
                LblContentModalBody.Text = "İçerik silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalContentInformation();", true);
            }
            else
            {
                LblContentModalHeader.Text = "İçerik Silme Başarısız";
                LblContentModalBody.Text = "İçerik silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalContentInformation();", true);
            }
        }
    }
}