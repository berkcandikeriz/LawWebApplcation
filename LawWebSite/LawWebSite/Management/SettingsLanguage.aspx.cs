using LawWebSite.Controller;
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
        protected void lnkAddLanguage_Click(object sender, EventArgs e)
        {
            Models.Language newLanguage = new Models.Language()
            {
     
                Name = txtLanguageName.Text,
                Flag = txtLanguageFlag.Text
            };

            var result = languageController.InsertLanguage(newLanguage);

            if (!result.Is_Error)
            {
                GetLanguages();
                txtLanguageName.Text = string.Empty;
                txtLanguageFlag.Text = string.Empty;
            }
            else
            {
                // Hata durumunda uygun işlemleri gerçekleştirin
            }
        }


        protected void lnkCloseLanguage_Click(object sender, EventArgs e)
        {

        }
    }
}