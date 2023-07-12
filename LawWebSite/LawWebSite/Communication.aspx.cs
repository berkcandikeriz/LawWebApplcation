using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Communication : System.Web.UI.Page
    {
        ContentController contentController = new ContentController();
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBody();
        }

        private void RenderBody()
        {
           
            var contentModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblWorkHour").Model;
            if (contentModel != null && contentModel.Any())
            {
                LblWorkHour.Text = contentModel.FirstOrDefault().Description;
            }
            var contentInformation = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblContactInformation").Model; 
            if (contentInformation != null && contentInformation.Any())
            {
                LblContactInformation.Text = contentInformation.FirstOrDefault().Description;
            }
        }
    }
}