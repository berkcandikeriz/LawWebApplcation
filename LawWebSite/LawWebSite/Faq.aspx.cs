using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Faq : System.Web.UI.Page
    {
        #region
       FaqController faqController = new FaqController();
        ContentController contentController = new ContentController();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetFaqs();
                RenderBody();
            }
        }
        private void RenderBody()
        {
            ReturnModel<Models.Content> GetContentFaqForm = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFaq");
            if (!GetContentFaqForm.Is_Error)
            {
                LblFaq.Text = GetContentFaqForm.Model.FirstOrDefault().Description;
                Page.Title = GetContentFaqForm.Model.FirstOrDefault().Description;
            }
        }

        private void GetFaqs()
        {
            ReturnModel<Models.Faq> GetFaqList = faqController.GetFaqsByLanguageId(Global.GlobalLanguage.LanguageId);
            if (!GetFaqList.Is_Error)
            {
                RFaqs.DataSource = GetFaqList.Model;
                RFaqs.DataBind();

            }
        }
    }
}