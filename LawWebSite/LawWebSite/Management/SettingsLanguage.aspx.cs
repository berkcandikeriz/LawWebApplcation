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
    public partial class SettingsLanguage : System.Web.UI.Page
    {
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetLanguages();
          
            }
       
        }
        private void GetLanguages()
        {
            var getLanguageModel = languageController.GetLanguages();
            if (!getLanguageModel.Is_Error)
            {
                RLanguages.DataSource = getLanguageModel.Model;
                RLanguages.DataBind();
            }
        }

        protected void Clear()
        {
            txtLanguageName.Text = string.Empty;
            txtLanguageFlag.Text = string.Empty;
        }

        protected void lnkAddLanguage_Click(object sender, EventArgs e)
        {
            if (Session["selectedLanguageItem"] != null)
            {
                Models.Language selectedLanguageItem = Session["selectedLanguageItem"] as Models.Language;
                selectedLanguageItem.Name = txtLanguageName.Text;
                selectedLanguageItem.Flag = txtLanguageFlag.Text;

                var result = languageController.UpdateLanguage(selectedLanguageItem);

                if (!result.Is_Error)
                {
                    LblLanguageModalHeader.Text = "Language Update Successful";
                    LblLanguageModalBody.Text = "The language has been successfully updated.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpLanguageModalInformation();", true);

                    GetLanguages();
                    Clear();
                    Session["selectedLanguageItem"] = null;
                }
                else
                {
                    LblLanguageModalHeader.Text = result.Message_Header;
                    LblLanguageModalBody.Text = result.Message_Content;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpLanguageModalInformation();", true);
                }
            }
            else
            {
                Models.Language newLanguage = new Models.Language()
                {
                    Name = txtLanguageName.Text,
                    Flag = txtLanguageFlag.Text
                };

                var result = languageController.InsertLanguage(newLanguage);

                if (!result.Is_Error)
                {
                    LblLanguageModalHeader.Text = "Language Addition Successful";
                    LblLanguageModalBody.Text = "The language has been successfully added.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpLanguageModalInformation();", true);

                    GetLanguages();
                    Clear();
                }
                else
                {
                    LblLanguageModalHeader.Text = result.Message_Header;
                    LblLanguageModalBody.Text = result.Message_Content;
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpLanguageModalInformation();", true);
                }
            }
        }



        protected void LbLanguageModalEdit_Click(object sender, EventArgs e)
        {
            string languageId = ((LinkButton)sender).CommandArgument;
            var result = languageController.GetLanguageByLanguageId(int.Parse(languageId));
            LblLanguageAddEditHeader.Text = languageId + "# Numaralı Dil Güncelle";
            lnkAddLanguage.Text = "Dil Güncelle";

            if (!result.Is_Error)
            {
                Models.Language selectedLanguageItem = result.Model[0];
                txtLanguageName.Text = selectedLanguageItem.Name;
                txtLanguageFlag.Text = selectedLanguageItem.Flag;

                Session["selectedLanguageItem"] = selectedLanguageItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbEdit();", true);
            }
        }

        protected void LbLanguageModalDelete_Click(object sender, EventArgs e)
        {
            string languageId = (sender as LinkButton).CommandArgument;

            var result = languageController.DeleteLanguage(languageId);

            if (!result.Is_Error)
            {
                GetLanguages();

                LblLanguageModalHeader.Text = "Dil Silme Başarılı";
                LblLanguageModalBody.Text = "Dil silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpLanguageModalInformation();", true);
            }
            else
            {
                LblLanguageModalHeader.Text = "Dil Silme Başarısız";
                LblLanguageModalBody.Text = "Dil silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpLanguageModalInformation();", true);
            }
        }

        protected void LbLanguageEkle_Click(object sender, EventArgs e)
        {
            LblLanguageAddEditHeader.Text = "Yeni Dil Ekle";
            lnkAddLanguage.Text = "Yeni Dil Ekle";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "LbLanguageEdit();", true);
        }



    }
}