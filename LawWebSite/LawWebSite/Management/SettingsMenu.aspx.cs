using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsMenu : System.Web.UI.Page
    {
        MenuController menuController = new MenuController();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMenus();

        }

        private void GetMenus()
        {
            var getMenuModel = menuController.GetMenus();
            if (!getMenuModel.Is_Error)
            {
                var sortedMenus = getMenuModel.Model.OrderBy(m => m.Order).ToList();
                RMenus.DataSource = sortedMenus;
                RMenus.DataBind();
            }
        }

      

        protected void lnkAddMenu_Click(object sender, EventArgs e)
        {
            Models.Menu newMenu = new Models.Menu()
            {
                LanguageId = int.Parse(txtDilId.Text),
                Name = txtIsim.Text,
                Url = txtUrl.Text,
                Order = int.Parse(txtSiralama.Text),
                Location = int.Parse(txtKonum.Text)
            };

         
            var result = menuController.InsertMenu(newMenu);

            if (!result.Is_Error)
            {
               
                GetMenus();

            
                txtDilId.Text = string.Empty;
                txtIsim.Text = string.Empty;
                txtUrl.Text = string.Empty;
                txtSiralama.Text = string.Empty;
                txtKonum.Text = string.Empty;
            }
            else
            {
               
            }
        }


        protected void lnkCloseMenu_Click(object sender, EventArgs e)
        {
     
        }


    }
}