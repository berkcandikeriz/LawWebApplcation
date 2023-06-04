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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMenus();
        }

        private void GetMenus()
        {
            RMenus.DataSource = menuController.GetMenusByLanguageId(Global.GlobalLanguage.LanguageId).Model;
            RMenus.DataBind();
        }
    }
}