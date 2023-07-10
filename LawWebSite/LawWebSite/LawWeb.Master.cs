using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class LawWeb : System.Web.UI.MasterPage
    {
        MenuController menuController = new MenuController();
        ContentController contentController = new ContentController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMenus();
            RenderBody();
        }

        private void RenderBody()
        {
            LblCopyright.Text = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblCopyright").Model.FirstOrDefault().Description;
            LblFooterColumn4.Text = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblFooterColumn4").Model.FirstOrDefault().Description;
        }

        private void GetMenus()
        {
            RMenus.DataSource = menuController.GetMenusByLanguageId(Global.GlobalLanguage.LanguageId).Model;
            RMenus.DataBind();
        }
    }
}