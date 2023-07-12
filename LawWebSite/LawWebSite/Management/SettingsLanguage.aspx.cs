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
            GetLanguages();
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
    }
}